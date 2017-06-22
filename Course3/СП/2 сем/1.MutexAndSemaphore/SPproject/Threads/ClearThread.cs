namespace SPproject.Threads
{
    class ClearThread : MyThread
    {
        public ClearThread(string name, int type) : base(name, type) { }

        protected override void Action()
        {
            SharedData.Text = "";
        }
    }
}
