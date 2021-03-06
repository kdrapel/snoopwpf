﻿namespace Snoop.Views.DebugListenerTab
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SnoopDebugListener : TraceListener
    {
        private readonly IList<IListener> listeners = new List<IListener>();

        public void RegisterListener(IListener listener)
        {
            this.listeners.Add(listener);
        }

        public const string ListenerName = "SnoopDebugListener";

        public SnoopDebugListener()
        {
            this.Name = ListenerName;
        }

        public override void WriteLine(string str)
        {
            this.SendDataToListeners(str);
        }

        public override void Write(string str)
        {
            this.SendDataToListeners(str);
        }

        private void SendDataToListeners(string str)
        {
            foreach (var listener in this.listeners)
            {
                listener.Write(str);
            }
        }

        public override void Write(string message, string category)
        {
            this.SendDataToListeners(message);

            base.Write(message, category);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            this.SendDataToListeners(message);
            base.TraceEvent(eventCache, source, eventType, id, message);
        }

        public override void Write(object o, string category)
        {
            base.Write(o, category);
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            base.TraceData(eventCache, source, eventType, id, data);
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            this.SendDataToListeners(source);
            base.TraceData(eventCache, source, eventType, id, data);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            base.TraceEvent(eventCache, source, eventType, id);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            base.TraceEvent(eventCache, source, eventType, id, format, args);
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message, Guid relatedActivityId)
        {
            base.TraceTransfer(eventCache, source, id, message, relatedActivityId);
        }

        public override void WriteLine(object o, string category)
        {
            base.WriteLine(o, category);
        }

        public override void Write(object o)
        {
            base.Write(o);
        }

        public override void WriteLine(object o)
        {
            base.WriteLine(o);
        }

        public override void WriteLine(string message, string category)
        {
            base.WriteLine(message, category);
        }

        public override void Fail(string message)
        {
            base.Fail(message);
        }

        public override void Fail(string message, string detailMessage)
        {
            base.Fail(message, detailMessage);
        }
    }
}
