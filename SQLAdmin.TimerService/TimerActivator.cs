﻿using SQLAdmin.TimerContract;
using SQLAdmin.TimerMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQLAdmin.TimerService
{
    public static class TimerActivator
    {
        private static Queue<Schedule> mTasks = new Queue<Schedule>();
        private static bool mIsRun = false;

        public static void Start()
        {
            mIsRun = true;
            ReviewSchedule();
            ExecuteQueue();
        }

        public static void Stop()
        {
            mIsRun = false;
        }

        private static void ReviewSchedule()
        {
            Task.Run(() =>
            {
                ScheduleService scheduleService = new ScheduleService();
                while (mIsRun)
                {
                    List<Schedule> schedules = scheduleService.GetSchedules();
                    if (schedules != null)
                    {
                        foreach (var schedule in schedules)
                        {
                            if (schedule.NextTime <= DateTime.UtcNow)
                            {
                                mTasks.Enqueue(schedule);
                                schedule.NextTime = CalculateNextTime(schedule);
                            }
                        }
                    }
                    Thread.Sleep(30000);
                }
            });
        }

        private static DateTime CalculateNextTime(Schedule schedule)
        {
            var addTimeSpan = TimeSpan.MinValue;
            switch(schedule.IntervalType)
            {
                case IntervalType.Hour:addTimeSpan = new TimeSpan(schedule.Interval, 0, 0); break;
                case IntervalType.Day:addTimeSpan = new TimeSpan(schedule.Interval * 24, 0, 0); break;
            }
            return schedule.NextTime.Add(addTimeSpan);
        }

        private static void ExecuteQueue()
        {
            Task.Run(() =>
            {
                while (mIsRun)
                {
                    if(mTasks.Count>0)
                    {
                        Schedule task = mTasks.Dequeue();
                        ThreadPool.QueueUserWorkItem(d => ExecuteTask(task));
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
            });
        }

        private static void ExecuteTask(Schedule task)
        {
            try
            {
                Assembly taskAssembly = Assembly.Load(task.Assembly);
                var taskType = taskAssembly.CreateInstance(task.Type);
                taskType.GetType().GetMethod(task.Method).Invoke(taskType, null);
            }
            catch (Exception e)
            {
            }
        }
    }
}