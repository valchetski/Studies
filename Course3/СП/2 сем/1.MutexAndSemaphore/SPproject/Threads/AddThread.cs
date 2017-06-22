namespace SPproject.Threads
{
    public class AddThread : MyThread
    {
        public AddThread(string name, int type) : base(name, type) { }

        protected override void Action()
        {
            SharedData.Text += "Первый поток";
        }
    }
}
