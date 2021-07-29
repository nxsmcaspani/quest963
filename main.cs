using System;

class BeerEncapsulator {
  private float _avalaibleBeerVolume ;
  private int _avalaibleBottles ;
  private int _avalaibleCapsules;

  public float GetAvailableBeerVolume(){
    return this._avalaibleBeerVolume;
  }
  public int GetAvailableBottes(){
    return this._avalaibleBottles;
  }
  public int GetAvailableCapsules(){
    return this._avalaibleCapsules;
  }
  
  public void AddBeer(float moreBeer){
    this._avalaibleBeerVolume+=moreBeer;
  }

  public void SetAvalaibleBeerVolume(float volume){
      this._avalaibleBeerVolume=volume;
  }

  public void SetAvailableBottles(int avalaibleBottles){
    this._avalaibleBottles = avalaibleBottles;
  }

  public void SetAvailableCapsules(int avalaibleCapsules){
    this._avalaibleCapsules = avalaibleCapsules;
  }

  public void InitEncapsulator(){
    Console.WriteLine("How many empty bottles are available ? ");
    while(true){
      int emptyBottles = Convert.ToInt32(Console.ReadLine());
      if(emptyBottles<=0){
        Console.WriteLine("Please provide an amount of bottles > 0");
      } else {
          this.SetAvailableBottles(emptyBottles);
          break;
      }
    }
    Console.WriteLine("How many capsules available ? ");
    while(true){
      int emptyCaps = Convert.ToInt32(Console.ReadLine());
      if(emptyCaps<=0){
        Console.WriteLine("Please provide an amount of capsules > 0");
      } else {
          this.SetAvailableCapsules(emptyCaps);
          break;
      }
    }    
    Console.WriteLine("How many liters of beer available ? ");
    while(true){
      float beerLiters = Single.Parse(Console.ReadLine());
      if(beerLiters<=0f){
        Console.WriteLine("Please a volume of beer > 0");
      } else {
          this.SetAvalaibleBeerVolume(beerLiters);
          break;
      }
    }
  }

  public void Encapsulate(int bottlesQty){
    if(this._avalaibleBottles-bottlesQty<0 || this._avalaibleCapsules-bottlesQty<0 || this._avalaibleBeerVolume-((float)bottlesQty*0.33f)<0f ){
        Console.WriteLine("Can't encapsulate that much, missing:");
        if(this._avalaibleBottles-bottlesQty<0) { 
          Console.WriteLine("At least "+(bottlesQty-this._avalaibleBottles)+" bottles");
        }
        if(this._avalaibleCapsules-bottlesQty<0 ){
          Console.WriteLine("At least "+(bottlesQty-this._avalaibleCapsules)+" capsules");
        }
        if(this._avalaibleBeerVolume-((float)bottlesQty*0.33f) <0f){
          Console.WriteLine("At least "+(((float)bottlesQty*0.33f)-this._avalaibleBeerVolume)+" liters of beer");
        }        
    } else {
      Console.WriteLine("Job's done! The machine just encapsulated "+this.ProduceEncapsulatedBeerBottles(bottlesQty)+" bottles of fine beer");
    }
  }

  private int ProduceEncapsulatedBeerBottles(int bottlesAmount){
  if(this._avalaibleBottles-bottlesAmount<0 || 
        this._avalaibleCapsules-bottlesAmount<0 ||
        this._avalaibleBeerVolume-((float)bottlesAmount*0.33f) <0f) return 0;
    this.SetAvailableBottles(this._avalaibleBottles-bottlesAmount);
    this.SetAvailableCapsules(this._avalaibleCapsules-bottlesAmount);
    this.SetAvalaibleBeerVolume(this._avalaibleBeerVolume-((float)bottlesAmount*0.33f));
    return bottlesAmount;
  }

  public static void Main (string[] args) {
    BeerEncapsulator machine = new BeerEncapsulator();
    Console.WriteLine("Initializing the encapsulation machine...");
    machine.InitEncapsulator();
    while(true){
      Console.WriteLine("How many beers do you want to encapsulate (type 'done' if you have enough) ?");
      string beers = Console.ReadLine();
      if(beers.Equals("done")){ 
        Console.WriteLine("Thank you for using that Encapsulator. Bye!");
        break;
      }
      if (Int32.TryParse(beers, out int beersQty)) {
        machine.Encapsulate(beersQty);
      } else {
        Console.WriteLine("I don't know what to do with your order of ["+beers+"]. Please try again.");
      }
    }   
  }
}