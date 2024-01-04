using Godot;
using System;

public class CustomTabContainer : Node2D
{
	[Export] public bool currentlyActive;
	
	private TextureButton _tab1;
	private TextureButton _tab2;
	private TextureButton _tab3;
	private TextureButton _tab4;
	
	public Sprite _panel1;
	public Sprite _panel2;
	public Sprite _panel3;
	public Sprite _panel4;

	private bool active;

	
	[Export] public bool sound1left;
	[Export] public bool sound2left;
	[Export] public bool sound3left;
	[Export] public bool sound4left;
	[Export] public bool sound5left;
	[Export] public bool sound6left;
	[Export] public bool sound7left;
	[Export] public bool sound8left;
	[Export] public bool sound9left;
	[Export] public bool sound10left;
	[Export] public bool sound11left;
	[Export] public bool sound12left;
	[Export] public bool sound13left;
	[Export] public bool sound14left;
	[Export] public bool sound15left;
	[Export] public bool sound16left;

	private KinematicBody2D _sound1;
	private KinematicBody2D _sound2;
	private KinematicBody2D _sound3;
	private KinematicBody2D _sound4;
	private KinematicBody2D _sound5;
	private KinematicBody2D _sound6;
	private KinematicBody2D _sound7;
	private KinematicBody2D _sound8;
	private KinematicBody2D _sound9;
	private KinematicBody2D _sound10;
	private KinematicBody2D _sound11;
	private KinematicBody2D _sound12;
	private KinematicBody2D _sound13;
	private KinematicBody2D _sound14;
	private KinematicBody2D _sound15;
	private KinematicBody2D _sound16;

	private Area2D _area1;
	private Area2D _area2;
	private Area2D _area3;
	private Area2D _area4;
	private Area2D _area5;
	private Area2D _area6;
	private Area2D _area7;
	private Area2D _area8;
	private Area2D _area9;
	private Area2D _area10;
	private Area2D _area11;
	private Area2D _area12;
	private Area2D _area13;
	private Area2D _area14;
	private Area2D _area15;
	private Area2D _area16;

	private bool firstTab;
	
	
	public override void _Ready()
	{
		_panel1 = GetNode<Sprite>("Sprite");
		_panel2 = GetNode<Sprite>("Sprite2");
		_panel3 = GetNode<Sprite>("Sprite3");
		_panel4 = GetNode<Sprite>("Sprite4");
		
		_tab1=GetNode<TextureButton>("Tab1");
		_tab2=GetNode<TextureButton>("Tab2");
		_tab3=GetNode<TextureButton>("Tab3");
		_tab4=GetNode<TextureButton>("Tab4");

		_sound1 = GetNode<KinematicBody2D>("Sound1");
		_sound2 = GetNode<KinematicBody2D>("Sound2");
		_sound3 = GetNode<KinematicBody2D>("Sound3");
		_sound4 = GetNode<KinematicBody2D>("Sound4");
		_sound5 = GetNode<KinematicBody2D>("Sound5");
		_sound6 = GetNode<KinematicBody2D>("Sound6");
		_sound7 = GetNode<KinematicBody2D>("Sound7");
		_sound8 = GetNode<KinematicBody2D>("Sound8");
		_sound9 = GetNode<KinematicBody2D>("Sound9");
		_sound10 = GetNode<KinematicBody2D>("Sound10");
		_sound11 = GetNode<KinematicBody2D>("Sound11");
		_sound12 = GetNode<KinematicBody2D>("Sound12");
		_sound13 = GetNode<KinematicBody2D>("Sound13");
		_sound14 = GetNode<KinematicBody2D>("Sound14");
		_sound15 = GetNode<KinematicBody2D>("Sound15");
		_sound16 = GetNode<KinematicBody2D>("Sound16");
		
		_area1 = GetNode<Area2D>("Sound1/Area2D");
		_area2 = GetNode<Area2D>("Sound2/Area2D");
		_area3 = GetNode<Area2D>("Sound3/Area2D");
		_area4 = GetNode<Area2D>("Sound4/Area2D");
		_area5 = GetNode<Area2D>("Sound5/Area2D");
		_area6 = GetNode<Area2D>("Sound6/Area2D");
		_area7 = GetNode<Area2D>("Sound7/Area2D");
		_area8 = GetNode<Area2D>("Sound8/Area2D");
		_area9 = GetNode<Area2D>("Sound9/Area2D");
		_area10 = GetNode<Area2D>("Sound10/Area2D");
		_area11 = GetNode<Area2D>("Sound11/Area2D");
		_area12 = GetNode<Area2D>("Sound12/Area2D");
		_area13 = GetNode<Area2D>("Sound13/Area2D");
		_area14 = GetNode<Area2D>("Sound14/Area2D");
		_area15 = GetNode<Area2D>("Sound15/Area2D");
		_area16 = GetNode<Area2D>("Sound16/Area2D");
		
		_tab1.Connect("pressed", this, nameof(ThisPressed), new Godot.Collections.Array { _tab1});
		_tab2.Connect("pressed", this, nameof(ThisPressed),new Godot.Collections.Array { _tab2});
		_tab3.Connect("pressed", this, nameof(ThisPressed),new Godot.Collections.Array { _tab3});
		_tab4.Connect("pressed", this, nameof(ThisPressed),new Godot.Collections.Array { _tab4});
		
		_tab1.Modulate = new Color(1,1,1,1);
		_tab2.Modulate = new Color(1,1,1,0.5f);
		_tab3.Modulate = new Color(1,1,1,0.5f);
		_tab4.Modulate = new Color(1,1,1,0.5f);

		_area1.Monitoring = true;
		_area2.Monitoring = true;
		_area3.Monitoring = true;
		_area4.Monitoring = true;
		_area5.Monitoring = false;
		_area6.Monitoring = false;
		_area7.Monitoring = false;
		_area8.Monitoring = false;
		_area9.Monitoring = false;
		_area10.Monitoring = false;
		_area11.Monitoring = false;
		_area12.Monitoring = false;
		_area13.Monitoring = false;
		_area14.Monitoring = false;
		_area15.Monitoring = false;
		_area16.Monitoring = false;
		
		_area1.Monitorable = true;
		_area2.Monitorable = true;
		_area3.Monitorable = true;
		_area4.Monitorable = true;
		_area5.Monitorable = false;
		_area6.Monitorable = false;
		_area7.Monitorable = false;
		_area8.Monitorable = false;
		_area9.Monitorable = false;
		_area10.Monitorable = false;
		_area11.Monitorable = false;
		_area12.Monitorable = false;
		_area13.Monitorable = false;
		_area14.Monitorable = false;
		_area15.Monitorable = false;
		_area16.Monitorable = false;

		//firstTab = true;
		//ThisPressed(_tab1);
		ShowCurrentPanel(_tab1);
	}



	public void ThisPressed(TextureButton tab)
	{
		GD.Print(sound1left);
		ModulateTab(tab);
		ShowCurrentPanel(tab);
	}

	public void ModulateTab(TextureButton  tab)
	{
		_tab1.Modulate = new Color(1,1,1,0.5f);
		_tab2.Modulate = new Color(1,1,1,0.5f);
		_tab3.Modulate = new Color(1,1,1,0.5f);
		_tab4.Modulate = new Color(1,1,1,0.5f);
		tab.Modulate = new Color(1,1,1,1);
	}

	public void ShowCurrentPanel(TextureButton  tab)
	{
		GD.Print("ShowCurrentPanel _sound1.visible: "+sound1left);
		_panel1.Visible = false;
		_panel2.Visible = false;
		_panel3.Visible = false;
		_panel4.Visible = false;
		CheckifLeft();
		
		if (tab.Name == "Tab1" || firstTab == true)
		{
			_panel1.Visible = true;
		
			_sound1.Visible = true;
			_sound2.Visible = true;
			_sound3.Visible = true;
			_sound4.Visible = true;

			_area1.Monitoring = true;
			_area2.Monitoring = true;
			_area3.Monitoring = true;
			_area4.Monitoring = true;
			
			_area1.Monitorable = true;
			_area2.Monitorable = true;
			_area3.Monitorable = true;
			_area4.Monitorable = true;

			firstTab = false;

		}
		
		else if (tab.Name == "Tab2")
		{
			_panel2.Visible = true;
			
			_sound5.Visible = true;
			_sound6.Visible = true;
			_sound7.Visible = true;
			_sound8.Visible = true;
			
			_area5.Monitoring = true;
			_area6.Monitoring = true;
			_area7.Monitoring = true;
			_area8.Monitoring = true;
			
			_area5.Monitorable = true;
			_area6.Monitorable = true;
			_area7.Monitorable = true;
			_area8.Monitorable = true;
		}
		else if (tab.Name == "Tab3")
		{
			_panel3.Visible = true;
		
			_sound9.Visible = true;
			_sound10.Visible = true;
			_sound11.Visible = true;
			_sound12.Visible = true;
			
			_area9.Monitoring = true;
			_area10.Monitoring = true;
			_area11.Monitoring = true;
			_area12.Monitoring = true;
			
			_area9.Monitorable = true;
			_area10.Monitorable = true;
			_area11.Monitorable = true;
			_area12.Monitorable = true;
		}
			
		else if (tab.Name == "Tab4")
		{
			_panel4.Visible = true;
			
			_sound13.Visible = true;
			_sound14.Visible = true;
			_sound15.Visible = true;
			_sound16.Visible = true;
			
			_area13.Monitoring = true;
			_area14.Monitoring = true;
			_area15.Monitoring = true;
			_area16.Monitoring = true;
			
			_area13.Monitorable = true;
			_area14.Monitorable = true;
			_area15.Monitorable = true;
			_area16.Monitorable = true;
		}
	}

	public void CheckifLeft()
	{
		if (sound1left == false)
		{
			_sound1.Visible = false;
			_area1.Monitoring = false;
			_area1.Monitorable = false;
		}
		else
		{
			_sound1.Visible = true;
			_area1.Monitoring = true;
			_area1.Monitorable = true;
		}
		if (sound2left == false)
		{
			_sound2.Visible = false;
			_area2.Monitoring = false;
			_area2.Monitorable = false;
		}
		else
		{
			_sound2.Visible = true;
			_area2.Monitoring = true;
			_area2.Monitorable = true;
		}
		if (sound3left == false)
		{
			_sound3.Visible = false;
			_area3.Monitoring = false;
			_area3.Monitorable = false;
		}
		else
		{
			_sound3.Visible = true;
			_area3.Monitoring = true;
			_area3.Monitorable = true;
		}
		if (sound4left == false)
		{
			_sound4.Visible = false;
			_area4.Monitoring = false;
			_area4.Monitorable = false;
		}
		else
		{
			_sound4.Visible = true;
			_area4.Monitoring = true;
			_area4.Monitorable = true;
		}
		if (sound5left == false)
		{
			_sound5.Visible = false;
			_area5.Monitoring = false;
			_area5.Monitorable = false;
		}
		else
		{
			_sound5.Visible = true;
			_area5.Monitoring = true;
			_area5.Monitorable = true;
		}
		if (sound6left == false)
		{
			_sound6.Visible = false;
			_area6.Monitoring = false;
			_area6.Monitorable = false;
		}
		else
		{
			_sound6.Visible = true;
			_area6.Monitoring = true;
			_area6.Monitorable = true;
		}
		if (sound7left == false)
		{
			_sound7.Visible = false;
			_area7.Monitoring = false;
			_area7.Monitorable = false;
		}
		else
		{
			_sound7.Visible = true;
			_area7.Monitoring = true;
			_area7.Monitorable = true;
		}
		if (sound8left == false)
		{
			_sound8.Visible = false;
			_area8.Monitoring = false;
			_area8.Monitorable = false;
		}
		else
		{
			_sound8.Visible = true;
			_area8.Monitoring = true;
			_area8.Monitorable = true;
		}
		if (sound9left == false)
		{
			_sound9.Visible = false;
			_area9.Monitoring = false;
			_area9.Monitorable = false;
		}
		else
		{
			_sound9.Visible = true;
			_area9.Monitoring = true;
			_area9.Monitorable = true;
		}
		if (sound10left == false)
		{
			_sound10.Visible = false;
			_area10.Monitoring = false;
			_area10.Monitorable = false;
		}
		else
		{
			_sound10.Visible = true;
			_area10.Monitoring = true;
			_area10.Monitorable = true;
		}
		if (sound11left == false)
		{
			_sound11.Visible = false;
			_area11.Monitoring = false;
			_area11.Monitorable = false;
		}
		else
		{
			_sound11.Visible = true;
			_area11.Monitoring = true;
			_area11.Monitorable = true;
		}
		if (sound12left == false)
		{
			_sound12.Visible = false;
			_area12.Monitoring = false;
			_area12.Monitorable = false;
		}
		else
		{
			_sound12.Visible = true;
			_area12.Monitoring = true;
			_area12.Monitorable = true;
		}
		if (sound13left == false)
		{
			_sound13.Visible = false;
			_area13.Monitoring = false;
			_area13.Monitorable = false;
		}
		else
		{
			_sound13.Visible = true;
			_area13.Monitoring = true;
			_area13.Monitorable = true;
		}
		if (sound14left == false)
		{
			_sound14.Visible = false;
			_area14.Monitoring = false;
			_area14.Monitorable = false;
		}
		else
		{
			_sound14.Visible = true;
			_area14.Monitoring = true;
			_area14.Monitorable = true;
		}
		if (sound15left == false)
		{
			_sound15.Visible = false;
			_area15.Monitoring = false;
			_area15.Monitorable = false;
		}
		else
		{
			_sound15.Visible = true;
			_area15.Monitoring = true;
			_area15.Monitorable = true;
		}
		if (sound16left == false)
		{
			_sound16.Visible = false;
			_area16.Monitoring = false;
			_area16.Monitorable = false;
		}
		else
		{
			_sound16.Visible = true;
			_area16.Monitoring = true;
			_area16.Monitorable = true;
		}
	}
	
	
	
	private void _on_CheckIfSoundInPanel_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Sound1")
			{
				sound1left = true;
			}
			if (kinematicBody.Name == "Sound2")
			{
				sound2left = true;
			}
			if (kinematicBody.Name == "Sound3")
			{
				sound3left = true;
			}
			if (kinematicBody.Name == "Sound4")
			{
				sound4left = true;
			}
			if (kinematicBody.Name == "Sound5")
			{
				sound5left = true;
			}
			if (kinematicBody.Name == "Sound6")
			{
				sound6left = true;
			}
			if (kinematicBody.Name == "Sound7")
			{
				sound7left = true;
			}
			if (kinematicBody.Name == "Sound8")
			{
				sound8left = true;
			}
			if (kinematicBody.Name == "Sound9")
			{
				sound9left = true;
			}
			if (kinematicBody.Name == "Sound10")
			{
				sound10left = true;
			}
			if (kinematicBody.Name == "Sound11")
			{
				sound11left = true;
			}
			if (kinematicBody.Name == "Sound12")
			{
				sound12left = true;
			}
			if (kinematicBody.Name == "Sound13")
			{
				sound13left = true;
			}
			if (kinematicBody.Name == "Sound14")
			{
				sound14left = true;
			}
			if (kinematicBody.Name == "Sound15")
			{
				sound15left = true;
			}
			if (kinematicBody.Name == "Sound16")
			{
				sound16left = true;
			}
		}
	}
	
	private void _on_CheckIfSoundInPanel_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Sound1")
			{
				sound1left = false;
			}
			if (kinematicBody.Name == "Sound2")
			{
				sound2left = false;
			}
			if (kinematicBody.Name == "Sound3")
			{
				sound3left = false;
			}
			if (kinematicBody.Name == "Sound4")
			{
				sound4left = false;
			}
			if (kinematicBody.Name == "Sound5")
			{
				sound5left = false;
			}
			if (kinematicBody.Name == "Sound6")
			{
				sound6left = false;
			}
			if (kinematicBody.Name == "Sound7")
			{
				sound7left = false;
			}
			if (kinematicBody.Name == "Sound8")
			{
				sound8left = false;
			}
			if (kinematicBody.Name == "Sound9")
			{
				sound9left = false;
			}
			if (kinematicBody.Name == "Sound10")
			{
				sound10left = false;
			}
			if (kinematicBody.Name == "Sound11")
			{
				sound11left = false;
			}
			if (kinematicBody.Name == "Sound12")
			{
				sound12left = false;
			}
			if (kinematicBody.Name == "Sound13")
			{
				sound13left = false;
			}
			if (kinematicBody.Name == "Sound14")
			{
				sound14left = false;
			}
			if (kinematicBody.Name == "Sound15")
			{
				sound15left = false;
			}
			if (kinematicBody.Name == "Sound16")
			{
				sound16left = false;
			}
		}
	}
	
	public void DisbaleCorrectArea(string sound)
	{
		if (sound == "Sound1")
		{
			_area1.Monitorable = false;
			_area1.Monitoring = false;
		}
		if (sound == "Sound2")
		{
			_area2.Monitorable = false;
			_area2.Monitoring = false;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = false;
			_area3.Monitoring = false;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = false;
			_area3.Monitoring = false;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = false;
			_area3.Monitoring = false;
		}
		if (sound == "Sound4")
		{
			_area4.Monitorable = false;
			_area4.Monitoring = false;
		}
		if (sound == "Sound5")
		{
			_area5.Monitorable = false;
			_area5.Monitoring = false;
		}
		if (sound == "Sound6")
		{
			_area6.Monitorable = false;
			_area6.Monitoring = false;
		}
		if (sound == "Sound7")
		{
			_area7.Monitorable = false;
			_area7.Monitoring = false;
		}
		if (sound == "Sound8")
		{
			_area8.Monitorable = false;
			_area8.Monitoring = false;
		}
		if (sound == "Sound9")
		{
			_area9.Monitorable = false;
			_area9.Monitoring = false;
		}
		if (sound == "Sound10")
		{
			_area10.Monitorable = false;
			_area10.Monitoring = false;
		}
		if (sound == "Sound11")
		{
			_area11.Monitorable = false;
			_area11.Monitoring = false;
		}
		if (sound == "Sound12")
		{
			_area12.Monitorable = false;
			_area12.Monitoring = false;
		}
		if (sound == "Sound13")
		{
			_area13.Monitorable = false;
			_area13.Monitoring = false;
		}
		if (sound == "Sound14")
		{
			_area14.Monitorable = false;
			_area14.Monitoring = false;
		}
		if (sound == "Sound15")
		{
			_area15.Monitorable = false;
			_area15.Monitoring = false;
		}
		if (sound == "Sound16")
		{
			_area16.Monitorable = false;
			_area16.Monitoring = false;
		}
			
		
	}
	
	public void EnableCorrectArea(string sound)
	{
		if (sound == "Sound1")
		{
			_area1.Monitorable = true;
			_area1.Monitoring = true;
		}
		if (sound == "Sound2")
		{
			_area2.Monitorable = true;
			_area2.Monitoring = true;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = true;
			_area3.Monitoring = true;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = true;
			_area3.Monitoring = true;
		}
		if (sound == "Sound3")
		{
			_area3.Monitorable = true;
			_area3.Monitoring = true;
		}
		if (sound == "Sound4")
		{
			_area4.Monitorable = true;
			_area4.Monitoring = true;
		}
		if (sound == "Sound5")
		{
			_area5.Monitorable = true;
			_area5.Monitoring = true;
		}
		if (sound == "Sound6")
		{
			_area6.Monitorable = true;
			_area6.Monitoring = true;
		}
		if (sound == "Sound7")
		{
			_area7.Monitorable = true;
			_area7.Monitoring = true;
		}
		if (sound == "Sound8")
		{
			_area8.Monitorable = true;
			_area8.Monitoring = true;
		}
		if (sound == "Sound9")
		{
			_area9.Monitorable = true;
			_area9.Monitoring = true;
		}
		if (sound == "Sound10")
		{
			_area10.Monitorable = true;
			_area10.Monitoring = true;
		}
		if (sound == "Sound11")
		{
			_area11.Monitorable = true;
			_area11.Monitoring = true;
		}
		if (sound == "Sound12")
		{
			_area12.Monitorable = true;
			_area12.Monitoring = true;
		}
		if (sound == "Sound13")
		{
			_area13.Monitorable = true;
			_area13.Monitoring = true;
		}
		if (sound == "Sound14")
		{
			_area14.Monitorable = true;
			_area14.Monitoring = true;
		}
		if (sound == "Sound15")
		{
			_area15.Monitorable = true;
			_area15.Monitoring = true;
		}
		if (sound == "Sound16")
		{
			_area16.Monitorable = true;
			_area16.Monitoring = true;
		}
	}
	
	private void _on_CheckIfSoundInPanel_mouse_entered()
	{
		
	}
	private void _on_CheckIfSoundInPanel_mouse_exited()
	{
		
	}
	
}















