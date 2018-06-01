using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    internal class PanelManager
    {
        public Stack<PanelBase> PanelStack = new Stack<PanelBase>();

        private static StartPanel startPanel = null;
        public static StartPanel StartPanel
        {
            get
            {
                if (startPanel == null)
                {
                    startPanel = new StartPanel();
                }
                return startPanel;
            }
        }

        private static UnitTestPanel unitTestPanel = null;
        public static UnitTestPanel UnitTestPanel
        {
            get
            {
                if (unitTestPanel == null)
                {
                    unitTestPanel = new UnitTestPanel();
                }
                return unitTestPanel;
            }
        }

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

        private static MessageBox messageBox = null;
        public static MessageBox MessageBox
        {
            get
            {
                if (messageBox == null)
                {
                    messageBox = new MessageBox();
                }
                return messageBox;
            }
        }

        private static FloatPanel floatPanel = null;
        public static FloatPanel FloatPanel
        {
            get
            {
                if (floatPanel == null)
                {
                    floatPanel = new FloatPanel();
                }
                return floatPanel;
            }
        }
    }
}