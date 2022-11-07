using Client._Classes;

namespace Client._Patterns_Designs._Strategy_Patern
{
    public abstract class MoveAlgorithm
    {

        public abstract void DoMovement(GamePlayer player);

        //dbr tiesiog apsirasysi paprasta judejima: letas/Vidutinis/greitas 
        //tai tikriausiai reiks viska persikelt is GameStats ar player class i atskiras ir form.cs atitinkamai viska uzpildyt
        //Sukurt atskiras klases kiekvienam judejimui

        // veliau viska ta pati tik su jumping
    }
}
