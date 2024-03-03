


public class SaveObject
{
    //Constructer
    public  SaveObject()
    {
        amountOfGem=0;
        amountOfStar=0;
    }
    public  SaveObject(int val1,int val2)
    {
        amountOfGem=val1;
        amountOfStar=val2;
    }
    public  SaveObject(SaveObject saveObject)
    {
        amountOfGem=saveObject.amountOfGem;
        amountOfStar=saveObject.amountOfStar;
        curretnSelectedCarIndex=saveObject.curretnSelectedCarIndex;
    }
   public int amountOfGem;
   public int amountOfStar;
   public int curretnSelectedCarIndex;
   public int[] playerCars=new int[10]{1,0,0,0,0,0,0,0,0,0};

}

