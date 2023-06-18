namespace GameProject.Controller.SupportClasses;

public class MakeAllButtonsInactiveClass
{
    public static void MakeAllButtonsInactive()
    {
        var buyAssetButton = Program.Game.GameRendering.BuyAssetButton;
        var sellAssetButton = Program.Game.GameRendering.SellAssetButton;
        var buttonToPutGuardOnProperty = Program.Game.GameRendering.ButtonToPutGuardOnProperty;
        var buttonToAttackProperty = Program.Game.GameRendering.ButtonToAttackProperty;
        var buttonToRecruitPeopleToGang = Program.Game.GameRendering.ButtonToRecruitPeopleToGang;
        
        buyAssetButton.ChangeToInactiveImage();
        sellAssetButton.ChangeToInactiveImage();
        buttonToPutGuardOnProperty.ChangeToInactiveImage();
        buttonToAttackProperty.ChangeToInactiveImage();
        buttonToRecruitPeopleToGang.ChangeToInactiveImage();
    }
}