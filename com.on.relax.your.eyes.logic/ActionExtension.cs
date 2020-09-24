using System.Runtime.CompilerServices;

namespace System
{
    public static partial class ActionExtension
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void FireAndReset(this Action handler)
        {
            if (null != handler)
            {
                handler();
            }
            ResetAll(handler);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void ResetAll(this Action handler)
        {
            if (null != handler)
            {
                foreach (var invocation in handler.GetInvocationList())
                {
                    handler -= (Action)invocation;
                }
            }
        }
    }
}
