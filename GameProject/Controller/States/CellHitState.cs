using GameProject.Controller.SupportClasses;
using GameProject.Model;
using GameProject.Model.ElementsOfField;
using GameProject.Model.ElementsOfField.CallFromPhone;
using GameProject.Model.ElementsOfPlay;
using GameProject.View;
using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework.Input;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class CellHitState : State
{
    public CellHitState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        var playerIndex = Field.CurrentPlayerIndex;
        var playerPosition = Field.Players[playerIndex].CurrentPosition;
        var currentCell = Field.FieldCells[playerPosition];
        var color = GetColourOfChipString.GetColourOfChip();
        AssignmentOfOutputInformationOnly.OutputTextAboutHitOnCell(color, currentCell);
        OverwritePlayerDataClass.OverwritePlayerData();
        ActivateButtonsToEndMoveHomeScreenExit();
        if (Field.Players[playerIndex].MoneyLeftOver < 0)
        {
            if (Field.Players[playerIndex].TotalValueProperty + Field.Players[playerIndex].MoneyLeftOver < 0)
            {
                Program.Game.Bankrupt = playerIndex;
                StoreOfStates.ChangeToSummingUpState();
            }
            else
            {
                ActivateBoxesForSale(playerIndex);
            }
        }
        else
        {
            if (currentCell is Asset cell)
            {
                var currentAsset = cell;
                if (currentAsset.Owner != Field.Players[playerIndex] &&
                    (currentAsset.Owner is null || currentAsset.Owner.PlayerId == -1))
                    ActivateButtonsBuyAndRecruitPeople(playerPosition, playerIndex);
                else if (currentAsset.Owner == Field.Players[playerIndex])
                    ActivateButtonsSellRecruitPeopleAndPutOnGuard(playerPosition, playerIndex);
                else if (currentAsset.Owner != Field.Players[playerIndex])
                    ActivateButtonToRecruitPeopleToAttackProperty(playerIndex);
                else StoreOfStates.ChangeState();
            }
            else if (currentCell is BlackBoxCard or SurpriseCard or CardOfRoadRepairs or CardPayYourTaxes
                     or ItsYourBirthday
                     or CallFromPhone or CornerCells)
            {
                StoreOfStates.ChangeState();
            }
        }
    }

    private static void ActivateBoxesForSale(int playerIndex)
    {
        AssignmentOfOutputInformationOnly.WarningIfYouRunOutOfMoney();
        var cellEntity = Program.Game.GameRendering.CellEntity;
        for (var i = 0; i < cellEntity.Length; i++)
        {
            if (Field.FieldCells[i] is Asset)
            {
                var currentAsset = Field.FieldCells[i] as Asset;
                if (currentAsset.Owner.PlayerId == playerIndex)
                {
                    var mouseOverAsset = cellEntity[i].Contains(Mouse.GetState().Position);
                    if (mouseOverAsset && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        Field.SellOffProperty(i, playerIndex);
                        Program.Game.GameRendering.ShowWhoPurchasedProperty(i, Program.Game.Content, 
                            playerIndex, BuyOrSale.Sale);
                        if (Field.Players[playerIndex].MoneyLeftOver >= 0)
                        {
                            StoreOfStates.ChangeState();
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void ActivateButtonsToEndMoveHomeScreenExit()
    {
        var previousText = Program.Game.GameRendering.InformationalText;
        var buttonToEndMove = Program.Game.GameRendering.ButtonToEndMove;
        buttonToEndMove.ChangeToActiveImage();
        var mouseOverButtonToEndMove =
            buttonToEndMove.SpriteRectangle.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

        var homeScreenExitButton = Program.Game.GameRendering.HomeScreenExitButton;
        homeScreenExitButton.ChangeToActiveImage();
        var mouseOverHomeScreenExitButton = homeScreenExitButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        
        var ruleButton = Program.Game.GameRendering.RuleButtonDuringGame;
        var mouseOverRuleButton = ruleButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        ruleButton.ChangeToActiveImage();
        
        if (mouseOverButtonToEndMove)
        {
            buttonToEndMove.ChangeToIlluminatedImage();
            homeScreenExitButton.ChangeToActiveImage();
            ruleButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.EndOfStrokeWarning();
        }
        else if (mouseOverHomeScreenExitButton)
        {
            homeScreenExitButton.ChangeToIlluminatedImage();
            buttonToEndMove.ChangeToActiveImage();
            ruleButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.DisplayStartScreenWarning();
        }
        else if (mouseOverRuleButton)
        {
            ruleButton.ChangeToIlluminatedImage();
            homeScreenExitButton.ChangeToActiveImage();
            buttonToEndMove.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.DisplayWarningAboutRules();
        }
        else
        {
            buttonToEndMove.ChangeToActiveImage();
            homeScreenExitButton.ChangeToActiveImage();
            ruleButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }

        if (mouseOverButtonToEndMove && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
            StoreOfStates.ChangeState();
        }
        else if (mouseOverHomeScreenExitButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeStateToStartScreen();
        }
        else if (mouseOverRuleButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeToRulesDuringGameState();
        }
    }

    private static void ActivateButtonsBuyAndRecruitPeople( int currentPosition, int chipIndex)
    {
        var currentAsset = Field.FieldCells[currentPosition] as Asset;
        var previousText = Program.Game.GameRendering.InformationalText;
        var buyAssetButton = Program.Game.GameRendering.BuyAssetButton;
        buyAssetButton.ChangeToActiveImage();
        var buttonToRecruitPeopleToGang = Program.Game.GameRendering.ButtonToRecruitPeopleToGang;
        buttonToRecruitPeopleToGang.ChangeToActiveImage();
        var mouseOverBuyAssetButton =
            buyAssetButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
        var mouseOverButtonToRecruitPeopleToGang =
            buttonToRecruitPeopleToGang.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);

        if (mouseOverBuyAssetButton)
        {
            buyAssetButton.ChangeToIlluminatedImage();
            buttonToRecruitPeopleToGang.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.PurchaseWarning(currentPosition);
        }
        else if (mouseOverButtonToRecruitPeopleToGang)
        {
            buttonToRecruitPeopleToGang.ChangeToIlluminatedImage();
            buyAssetButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.DisplayRecruitmentWarning(currentPosition);
        }
        else
        {
            buyAssetButton.ChangeToActiveImage();
            buttonToRecruitPeopleToGang.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }

        if (mouseOverButtonToRecruitPeopleToGang && Field.Players[chipIndex].MoneyLeftOver >= Gang.CostOfIncreasingGang 
                                                 && Mouse.GetState().LeftButton == ButtonState.Pressed)
            PerformActionOfRecruitmentButton(buyAssetButton, buttonToRecruitPeopleToGang, chipIndex);
        else if (mouseOverBuyAssetButton && Field.Players[chipIndex].MoneyLeftOver >= currentAsset.Price 
                                         && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            buyAssetButton.ChangeToInactiveImage();
            buttonToRecruitPeopleToGang.ChangeToInactiveImage();
            MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
            Field.BuyProperty(currentPosition, chipIndex);
            Program.Game.GameRendering.ShowWhoPurchasedProperty(currentPosition, Program.Game.Content, chipIndex, BuyOrSale.Buy);
        
            OverwritePlayerDataClass.OverwritePlayerData();
            StoreOfStates.ChangeState();
        }
    }

    private static void ActivateButtonsSellRecruitPeopleAndPutOnGuard(int currentPosition, int chipIndex)
    {
        var previousText = Program.Game.GameRendering.InformationalText;
        var sellAssetButton = Program.Game.GameRendering.SellAssetButton;
        sellAssetButton.ChangeToActiveImage();
        var mouseOverSellAssetButton =
            sellAssetButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
        var buttonToRecruitPeopleToGang = Program.Game.GameRendering.ButtonToRecruitPeopleToGang;
        buttonToRecruitPeopleToGang.ChangeToActiveImage();
        var mouseOverButtonToRecruitPeopleToGang =
            buttonToRecruitPeopleToGang.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        var areThereAnyPeopleAvailable = Field.Players[chipIndex].Gang.NumberOfPeopleAvailable > 0;
        var buttonToPutGuardOnProperty = Program.Game.GameRendering.ButtonToPutGuardOnProperty;
        var mouseButtonToPutGuardOnProperty =
            buttonToPutGuardOnProperty.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        buttonToPutGuardOnProperty.ChangeToActiveImage();

        if (mouseOverSellAssetButton)
        {
            sellAssetButton.ChangeToIlluminatedImage();
            buttonToRecruitPeopleToGang.ChangeToActiveImage();
            buttonToPutGuardOnProperty.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.WarningAboutSale(currentPosition);
        }
        else if (mouseOverButtonToRecruitPeopleToGang)
        {
            buttonToRecruitPeopleToGang.ChangeToIlluminatedImage();
            sellAssetButton.ChangeToActiveImage();
            buttonToPutGuardOnProperty.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.DisplayRecruitmentWarning(currentPosition);
        }
        else if (mouseButtonToPutGuardOnProperty)
        {
            buttonToPutGuardOnProperty.ChangeToIlluminatedImage();
            AssignmentOfOutputInformationOnly.DisplayArmingWarning(currentPosition);
            sellAssetButton.ChangeToActiveImage();
            buttonToRecruitPeopleToGang.ChangeToActiveImage();
        }
        else
        {
            sellAssetButton.ChangeToActiveImage();
            buttonToRecruitPeopleToGang.ChangeToActiveImage();
            buttonToPutGuardOnProperty.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }

        if (mouseOverButtonToRecruitPeopleToGang && Field.Players[chipIndex].MoneyLeftOver >= Gang.CostOfIncreasingGang
                                                 && Mouse.GetState().LeftButton == ButtonState.Pressed)
            PerformActionOfRecruitmentButton(sellAssetButton, buttonToRecruitPeopleToGang, chipIndex);
        else if (mouseOverSellAssetButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
            Field.SellOffProperty(currentPosition, chipIndex);
            Program.Game.GameRendering.ShowWhoPurchasedProperty(currentPosition, Program.Game.Content, chipIndex, BuyOrSale.Sale);
            OverwritePlayerDataClass.OverwritePlayerData();
            StoreOfStates.ChangeState();
        }
        else if (areThereAnyPeopleAvailable && mouseButtonToPutGuardOnProperty && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
            Field.PutGuardOnProperty(currentPosition);
            OverwritePlayerDataClass.OverwritePlayerData();
            StoreOfStates.ChangeState();
        }
    }

    private static void ActivateButtonToRecruitPeopleToAttackProperty(int chipIndex)
    {
        var currentPosition = Field.Players[chipIndex].CurrentPosition;
        var areThereAnyPeopleAvailable = Field.Players[chipIndex].Gang.NumberOfPeopleAvailable > 0;
        var previousText = Program.Game.GameRendering.InformationalText;
        var buttonToAttackProperty = Program.Game.GameRendering.ButtonToAttackProperty;
        buttonToAttackProperty.ChangeToActiveImage();
        var mouseOverButtonToAttackProperty =
            buttonToAttackProperty.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        
        if (mouseOverButtonToAttackProperty)
        {
            buttonToAttackProperty.ChangeToIlluminatedImage();
            AssignmentOfOutputInformationOnly.DisplayAttackWarning(currentPosition, chipIndex);
        }
        else
        {
            if (areThereAnyPeopleAvailable) buttonToAttackProperty.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }
        if (areThereAnyPeopleAvailable && mouseOverButtonToAttackProperty &&
            Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
            Field.RaidProperty(currentPosition);
            OverwritePlayerDataClass.OverwritePlayerData();
            StoreOfStates.ChangeState();
        }
    }

    private static void PerformActionOfRecruitmentButton(Button anotherButton, Button buttonToRecruitPeopleToGang, int chipIndex)
    {
        MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
        Field.IncreaseNumberOfPeopleInGang(chipIndex);
        OverwritePlayerDataClass.OverwritePlayerData();
        StoreOfStates.ChangeState();
    }
}