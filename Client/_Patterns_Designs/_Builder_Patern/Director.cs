namespace Client._Patterns_Designs._Builder_Patern
{
    public class Director
    {
        public void Construct(IBuilder builder)
        {
            if (builder == null) { throw new ArgumentNullException(); }
            builder.AddRing();
            builder.AddNeckless();
            builder.AddCrown();
        }
    }
}
