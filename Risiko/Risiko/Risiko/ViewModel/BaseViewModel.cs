using Risiko.Model;

namespace Risiko.ViewModel
{
    public class BaseViewModel : BaseModel
    {
        private int runningCounter;

        private bool loading;
        private bool enable;
        /// <summary>
        /// Indicates if the ViewModel is loading data.
        /// </summary>
        public bool Loading
        {
            get
            {
                return loading;
            }
            set
            {
                if (value != loading)
                {
                    loading = value;
                    OnPropertyChanged("Loading");
                }
            }
        }
        /// <summary>
        /// Indicates if the controls of the page are active.
        /// </summary>
        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                if (value != enable)
                {
                    enable = value;
                    OnPropertyChanged("Enable");
                }
            }
        }

        private void controllUI()
        {
            if (runningCounter == 0)
            {
                //release UI
                Loading = false;
                Enable = true;
            }
            else
            {
                //block UI
                Loading = true;
                Enable = false;
            }
        }

        /// <summary>
        /// Blocks the UI to do async loading/work.
        /// </summary>
        protected void blockUI()
        {
            lock (this)
            {
                runningCounter++;
                controllUI();
            }
        }

        /// <summary>
        /// Releases the UI after doing async loading/work.
        /// </summary>
        protected void releaseUI()
        {
            lock (this)
            {
                if (runningCounter > 0)
                {
                    runningCounter--;
                }
                controllUI();
            }
        }

        /// <summary>
        /// Creates a new BaseViewModel and sets default values for enable, loading and runningCounter.
        /// </summary>
        protected BaseViewModel()
        {
            enable = true;
            loading = false;
            runningCounter = 0;
        }
    }
}
