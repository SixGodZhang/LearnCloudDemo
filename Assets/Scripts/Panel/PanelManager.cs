using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class PanelManager
    {
        public Stack<PanelBase> PanelStack = new Stack<PanelBase>();

        private static LoginPanel loginPanel = null;
        public static LoginPanel LoginPanel
        {
            get
            {
                if (loginPanel == null)
                {
                    loginPanel = new LoginPanel();
                }
                return loginPanel;
            }
        }
    }
}
