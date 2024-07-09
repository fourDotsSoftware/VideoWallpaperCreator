using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace VideoWallpaperCreator
{
    class SetProcessPriorityHelperPartial
    {
        public static void SetProcessPriority(ref Process ps)
        {
            try
            {                               
                System.Threading.Thread.Sleep(300);

                if (ps.HasExited) return;
                //return;

                if (frmClip.Instance.ThreadPriorityLevel == frmClip.ThreadPriority.High)
                {
                    ps.PriorityClass = ProcessPriorityClass.High;
                    ps.PriorityBoostEnabled = true;

                    for (int k = 0; k < ps.Threads.Count; k++)
                    {
                        try
                        {
                            if (!ps.HasExited)
                            {
                                ps.Threads[k].PriorityLevel = ThreadPriorityLevel.Highest;
                            }
                        }
                        catch (Exception exp)
                        {


                        }
                    }
                }
                else if (frmClip.Instance.ThreadPriorityLevel == frmClip.ThreadPriority.Normal)
                {
                    ps.PriorityClass = ProcessPriorityClass.Normal;

                    for (int k = 0; k < ps.Threads.Count; k++)
                    {
                        try
                        {
                            if (!ps.HasExited)
                            {
                                ps.Threads[k].PriorityLevel = ThreadPriorityLevel.Normal;
                            }
                        }
                        catch (Exception exp) { }
                    }
                }
                else if (frmClip.Instance.ThreadPriorityLevel == frmClip.ThreadPriority.BelowNormal)
                {
                    ps.PriorityClass = ProcessPriorityClass.BelowNormal;

                    for (int k = 0; k < ps.Threads.Count; k++)
                    {
                        try
                        {
                            if (!ps.HasExited)
                            {
                                ps.Threads[k].PriorityLevel = ThreadPriorityLevel.BelowNormal;
                            }
                        }
                        catch (Exception exp) { }
                    }
                }
                else if (frmClip.Instance.ThreadPriorityLevel == frmClip.ThreadPriority.Idle)
                {
                    ps.PriorityClass = ProcessPriorityClass.Idle;

                    for (int k = 0; k < ps.Threads.Count; k++)
                    {
                        try
                        {
                            if (!ps.HasExited)
                            {
                                ps.Threads[k].PriorityLevel = ThreadPriorityLevel.Idle;
                            }
                        }
                        catch (Exception exp) { }
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}
