namespace SPproject.Threads
{
    class RemoveThread : MyThread
    {
        public RemoveThread(string name, int type): base(name, type) { }


        protected override void Action()
        {
            int index = SharedData.Text.LastIndexOf(" ");
            if (index > -1)
            {
                SharedData.Text = SharedData.Text.Substring(0, index);
            }
        }
    }
}
