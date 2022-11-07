namespace Client._Patterns_Designs._Builder_Patern
{
    public class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.AddRing();
            builder.AddNeckless();
            builder.AddCrown();
        }
    }
}
