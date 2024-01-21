using Godot;
using System;
using iText.StyledXmlParser.Jsoup.Select;


public class DropDownAttribute : OptionButton
{
	[Export] public bool FirstChar;
	public override void _Ready()
	{
		this.AddItem("Choose Ending");

	}

	public void DisableHover()
	{
		SetMouseFilter(MouseFilterEnum.Ignore);
	}

	public void EnabelHover()
	{
		SetMouseFilter(MouseFilterEnum.Stop);
	}

	public void Reset()
	{
		this.Select(0);
	}

	public void ClearItems()
	{
		this.RemoveItem(8);
		this.RemoveItem(7);
		this.RemoveItem(6);
		this.RemoveItem(5);
		this.RemoveItem(4);
		this.RemoveItem(3);
		this.RemoveItem(2);
		this.RemoveItem(1);
		this.RemoveItem(0);
	}

	public void EndingPerfect()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Heroic");
			this.AddItem("Talented");
			this.AddItem("Fulfilled");
			this.AddItem("Determined");
			this.AddItem("Well-liked");
			this.AddItem("Hopeless");
			this.AddItem("Egoistic");
			this.AddItem("Integrated");
		}
		else
		{
			ClearItems();
			this.AddItem("Befriended");
			this.AddItem("Loyal");
			this.AddItem("Integrated");
			this.AddItem("Heroic");
			this.AddItem("Cocky");
			this.AddItem("Aggressive");
			this.AddItem("Egoistic");
			this.AddItem("Talented");
		}
	}

	public void EndingOk()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Sacrificing");
			this.AddItem("Determinded");
			this.AddItem("Heroic");
			this.AddItem("Selfless");
			this.AddItem("Talented");
			this.AddItem("Fullfilled");
			this.AddItem("Thoughtless");
			this.AddItem("Hopeless");
		}
		else
		{
			ClearItems();
			this.AddItem("Leading");
			this.AddItem("Feels Guilty");
			this.AddItem("Integrated");
			this.AddItem("Heroic");
			this.AddItem("Fullfilled");
			this.AddItem("Twisted");
			this.AddItem("Talented");
			this.AddItem("Cocky");
		}
	}

	public void EndingCorrect()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Hopeless");
			this.AddItem("Depressed");
			this.AddItem("Determined");
			this.AddItem("Possessed");
			this.AddItem("Aggressive");
			this.AddItem("Egoistic");
			this.AddItem("Leading");
			this.AddItem("Twisted");
		}
		else
		{
			ClearItems();
			this.AddItem("Talented");
			this.AddItem("Aggressive");
			this.AddItem("Egoistic");
			this.AddItem("Cocky");
			this.AddItem("Determined");
			this.AddItem("Twisted");
			this.AddItem("Depressed");
			this.AddItem("Integrated");
		}
	}

	public void EndingPerfect2()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Feels Guilty");
			this.AddItem("Heroic");
			this.AddItem("Leading");
			this.AddItem("Depressed");
			this.AddItem("Fulfilled");
			this.AddItem("Ruthless");
			this.AddItem("Egoistic");
			this.AddItem("Well-liked");
		}
		else
		{
			ClearItems();
			this.AddItem("Sacrificing");
			this.AddItem("Ruthless");
			this.AddItem("Heroic");
			this.AddItem("Loyal");
			this.AddItem("Fulfilled");
			this.AddItem("Hopeless");
			this.AddItem("Thoughtless");
			this.AddItem("Cocky");
		}
	}

	public void EndingOk2()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Possessed");
			this.AddItem("Ruthless");
			this.AddItem("Egoistic");
			this.AddItem("Aggressive");
			this.AddItem("Betraying");
			this.AddItem("Hopeless");
			this.AddItem("Depressed");
			this.AddItem("Cocky");
		}
		else
		{
			ClearItems();
			this.AddItem("Heroic");
			this.AddItem("Betraying");
			this.AddItem("Integrated");
			this.AddItem("Twisted");
			this.AddItem("Depressed");
			this.AddItem("Well-Liked");
			this.AddItem("Fulfilled");
			this.AddItem("Forgiving");
		}
	}

	public void EndingCorrect2()
	{
		if (FirstChar == true)
		{
			ClearItems();
			this.AddItem("Fulfilled");
			this.AddItem("Determined");
			this.AddItem("Forgiving");
			this.AddItem("Integrated");
			this.AddItem("Ruthless");
			this.AddItem("Egoistic");
			this.AddItem("Heroic");
			this.AddItem("Sacrificing");
		}
		else
		{
			ClearItems();
			this.AddItem("Integrated");
			this.AddItem("Twisted");
			this.AddItem("Loyal");
			this.AddItem("Sacrificing");
			this.AddItem("Heroic");
			this.AddItem("Depressed");
			this.AddItem("Forgiving");
			this.AddItem("Befriended");
		}
	}
	
}

