using Godot;
using System;

public class OpenStory : Button
{
	//private Button _story1;
	private Label _ending1;
	private Label _ending2;
	private Label _ending3;
	private Label _ending21;
	private Label _ending22;
	private Label _ending23;
	private Label _ending31;
	private Label _ending32;
	private Label _ending33;
	
	private Label _story1;
	private Label _story2;
	private Label _story3;
	
	private Button _close;
	private ColorRect _background;
	
	public override void _Ready()
	{
		Connect("pressed", this, nameof(OnStory1Pressed));
		_ending1 = GetNode<Label>("/root/Narrative/EndingPopup/Ending1");
		_ending2 = GetNode<Label>("/root/Narrative/EndingPopup/Ending2");
		_ending3 = GetNode<Label>("/root/Narrative/EndingPopup/Ending3");
		_ending21 = GetNode<Label>("/root/Narrative/EndingPopup/Ending21");
		_ending22 = GetNode<Label>("/root/Narrative/EndingPopup/Ending22");
		_ending23 = GetNode<Label>("/root/Narrative/EndingPopup/Ending23");
		_ending31 = GetNode<Label>("/root/Narrative/EndingPopup/Ending31");
		_ending32 = GetNode<Label>("/root/Narrative/EndingPopup/Ending32");
		_ending33 = GetNode<Label>("/root/Narrative/EndingPopup/Ending33");
	
		_close = GetNode<Button>("/root/Narrative/EndingPopup/CloseStory");
		_background = GetNode<ColorRect>("/root/Narrative/EndingPopup/BackgroundEnding");
		_story1 = GetNode<Label>("/root/Narrative/EndingPopup/Story1");
		_story2 = GetNode<Label>("/root/Narrative/EndingPopup/Story2");
		_story3 = GetNode<Label>("/root/Narrative/EndingPopup/Story3");
		_close.Hide();
		_background.Hide();
		_close.Connect("pressed", this, nameof(OnClosePressed));
		_story1.Hide();
	}

	public void OnStory1Pressed()
	{
		//1
		if (this.Name == "Ending1")
		{
			_ending1.Show();
		}
		if (this.Name == "Ending2")
		{
			_ending2.Show();
		}
		if (this.Name == "Ending3")
		{
			_ending3.Show();
		}

		if (this.Name == "Story1")
		{
			_story1.Show();
		}
		//2
		if (this.Name == "Ending21")
		{
			_ending21.Show();
		}
		if (this.Name == "Ending22")
		{
			_ending22.Show();
		}
		if (this.Name == "Ending23")
		{
			_ending23.Show();
		}
		
		if (this.Name == "Story2")
		{
			_story2.Show();
		}
		
		//3
		if (this.Name == "Ending31")
		{
			_ending31.Show();
		}
		if (this.Name == "Ending32")
		{
			_ending32.Show();
		}
		if (this.Name == "Ending33")
		{
			_ending33.Show();
		}
		
		if (this.Name == "Story3")
		{
			_story3.Show();
		}
		_close.Show();
		_background.Show();
	}

	public void OnClosePressed()
	{
		_ending1.Hide();
		_ending2.Hide();
		_ending3.Hide();
		_ending21.Hide();
		_ending22.Hide();
		_ending23.Hide();
		_ending31.Hide();
		_ending32.Hide();
		_ending33.Hide();
		
		_close.Hide();
		_background.Hide();
		_story1.Hide();
		_story2.Hide();
		_story3.Hide();
		
	}
	
	public void DisableHover()
	{
		SetMouseFilter(MouseFilterEnum.Ignore);
	}

	public void EnabelHover()
	{
		SetMouseFilter(MouseFilterEnum.Stop);
	}
}
