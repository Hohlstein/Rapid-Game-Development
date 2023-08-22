//Enum and class for different Raritys for Dialogues, values can/should be adjusted
public enum Rarity
{
    common,
    rare,
    veryRare,
    problem,
    minigameSpecific,
    miniGameGeneric
}

public class RarityInfo {
    double minValue;
    double maxValue;
    public RarityInfo(Rarity rarity){
        if(rarity == Rarity.common){
            minValue = 0.0;
            maxValue = 0.6;
        }
        if(rarity == Rarity.rare){
            minValue = 0.61;
            maxValue = 0.9;
        }
        if(rarity == Rarity.veryRare){
            minValue = 0.91;
            maxValue = 1.0;
        }
    }
    public double getMinValue(){
        return minValue;
    }
    public double getMaxValue(){
        return maxValue;
    }
}