namespace Animals.Models;


//описва всяко едно животно
//abstract class -> държим само описание и не можем да създаваме обекти от него

public abstract class Animal
{
    //характеристики -> полета / пропърти -> име, любима храна
    //fields -> място, където да съхраняваме характеристиките
    private string name;
    private string favouriteFood;

    //properties -> осигурят достъп до полетата
    public string Name { get; set; }
    public string FavouriteFood { get; set;}

    //конструктор
    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    //действия -> методи
    public abstract void ExplainSelf(); //всяко едно животно да се представя
}
