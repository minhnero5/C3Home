
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [SerializeField] protected int maxLevelUpgrade = 9;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 2);
    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }

    protected virtual bool UpgradeItem(int itemIndex)
    {
        if (itemIndex >= this.inventory.Items.Count) return false;

        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevel = itemInventory.itemProfileSO.upgradeLevel;
        if(!this.ItemUpgradeable(upgradeLevel))return false;
        if (!this.HaveEnoughIngredients(upgradeLevel, itemInventory.upgradeLevel)) return false ;

        this.DeductIngredients(upgradeLevel,itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevel)
    {
        if(upgradeLevel.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevel, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if(currentLevel>upgradeLevel.Count)
        {
            Debug.Log("Item can't not upgrade anymore,current: " + currentLevel);
            return false;
        }

        ItemRecipe currentRecipeLevel = upgradeLevel[currentLevel];

        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;
            
            if(!this.inventory.ItemCheck(itemCode,itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevel,int currentLeve)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevel[currentLeve];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }
    }
}
