using Godot;
using System;

public class CustomTabContainer : Node2D
{
	[Export] public bool currentlyActive;

	private SoundSlider _soundSlider;
	private SoundSlider _soundSlider2;
	private SoundSlider _soundSlider3;
	private SoundSlider _soundSlider4;
	private SoundSlider _soundSlider5;
	private SoundSlider _soundSlider6;
	private SoundSlider _soundSlider7;
	private SoundSlider _soundSlider8;
	private SoundSlider _soundSlider9;

	private Sound _sound;
	
	
	private TextureButton _tab1;
	private TextureButton _tab2;
	private TextureButton _tab3;
	private TextureButton _tab4;
	
	public Sprite _panel1;
	public Sprite _panel2;
	public Sprite _panel3;
	public Sprite _panel4;

	private bool active;

	
	public bool sound1left;
	public bool sound2left;
	public bool sound3left;
	public bool sound4left;
	public bool sound5left;
	public bool sound6left;
	public bool sound7left;
	public bool sound8left;
	public bool sound9left;
	public bool sound10left;
	public bool sound11left;
	public bool sound12left;
	public bool sound13left;
	public bool sound14left;
	public bool sound15left;
	public bool sound16left;

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

	[Export] public Texture checkBox;
	[Export] public Texture checkBoxPressed;

	private string currentName;
	
	private TextureButton _checkbox1;
	private TextureButton _checkbox2;
	private TextureButton _checkbox3;
	private TextureButton _checkbox4;
	private TextureButton _checkbox5;
	private TextureButton _checkbox6;
	private TextureButton _checkbox7;
	private TextureButton _checkbox8;
	private TextureButton _checkbox9;
	private TextureButton _checkbox10;
	private TextureButton _checkbox11;
	private TextureButton _checkbox12;
	private TextureButton _checkbox13;
	private TextureButton _checkbox14;
	private TextureButton _checkbox15;
	private TextureButton _checkbox16;
	
	private string groupName = "CheckBox";
	private string currentlyChecked;
	private bool alreadyChecked;
	
	private TextureButton _editName1;
	private TextureButton _editName2;
	private TextureButton _editName3;
	private TextureButton _editName4;
	private TextureButton _editName5;
	private TextureButton _editName6;
	private TextureButton _editName7;
	private TextureButton _editName8;
	private TextureButton _editName9;
	private TextureButton _editName10;
	private TextureButton _editName11;
	private TextureButton _editName12;
	private TextureButton _editName13;
	private TextureButton _editName14;
	private TextureButton _editName15;
	private TextureButton _editName16;

	private LineEdit lineEditCopy;
	
	private LineEdit _lineEdit1;
	private LineEdit _lineEdit2;
	private LineEdit _lineEdit3;
	private LineEdit _lineEdit4;
	private LineEdit _lineEdit5;
	private LineEdit _lineEdit6;
	private LineEdit _lineEdit7;
	private LineEdit _lineEdit8;
	private LineEdit _lineEdit9;
	private LineEdit _lineEdit10;
	private LineEdit _lineEdit11;
	private LineEdit _lineEdit12;
	private LineEdit _lineEdit13;
	private LineEdit _lineEdit14;
	private LineEdit _lineEdit15;
	private LineEdit _lineEdit16;
	
	
	private DragAndDropSound _dragAndDropSound;
	private Label _selectedSound;

	private bool soundIsSelected;
	
	public override void _Ready()
	{
		_soundSlider = GetNode<SoundSlider>("/root/Sound/Moment1");
		_soundSlider2 = GetNode<SoundSlider>("/root/Sound/Moment2");
		_soundSlider3 = GetNode<SoundSlider>("/root/Sound/Moment3");
		_soundSlider4 = GetNode<SoundSlider>("/root/Sound/Moment4");
		_soundSlider5 = GetNode<SoundSlider>("/root/Sound/Moment5");
		_soundSlider6 = GetNode<SoundSlider>("/root/Sound/Moment6");
		_soundSlider7 = GetNode<SoundSlider>("/root/Sound/Moment7");
		_soundSlider8 = GetNode<SoundSlider>("/root/Sound/Moment8");
		_soundSlider9 = GetNode<SoundSlider>("/root/Sound/Moment9");

		_sound = GetNode<Sound>("/root/Sound");
		
		//_dragAndDropSound = GetNode<DragAndDropSound>("Sound1");
		_selectedSound = GetNode<Label>("SelectedSound");
		_selectedSound.Visible = false;
		
		_checkbox1 = GetNode<TextureButton>("Sound1/CheckBox1");
		_checkbox2 = GetNode<TextureButton>("Sound2/CheckBox2");
		_checkbox3 = GetNode<TextureButton>("Sound3/CheckBox3");
		_checkbox4 = GetNode<TextureButton>("Sound4/CheckBox4");
		_checkbox5 = GetNode<TextureButton>("Sound5/CheckBox5");
		_checkbox6 = GetNode<TextureButton>("Sound6/CheckBox6");
		_checkbox7 = GetNode<TextureButton>("Sound7/CheckBox7");
		_checkbox8 = GetNode<TextureButton>("Sound8/CheckBox8");
		_checkbox9 = GetNode<TextureButton>("Sound9/CheckBox9");
		_checkbox10 = GetNode<TextureButton>("Sound10/CheckBox10");
		_checkbox11 = GetNode<TextureButton>("Sound11/CheckBox11");
		_checkbox12 = GetNode<TextureButton>("Sound12/CheckBox12");
		_checkbox13 = GetNode<TextureButton>("Sound13/CheckBox13");
		_checkbox14 = GetNode<TextureButton>("Sound14/CheckBox14");
		_checkbox15 = GetNode<TextureButton>("Sound15/CheckBox15");
		_checkbox16 = GetNode<TextureButton>("Sound16/CheckBox16");
		
		_checkbox1.TextureNormal = checkBox;
		_checkbox2.TextureNormal = checkBox;
		
		_checkbox1.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox1});
		_checkbox2.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox2});
		_checkbox3.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox3});
		_checkbox4.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox4});
		_checkbox5.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox5});
		_checkbox6.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox6});
		_checkbox7.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox7});
		_checkbox8.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox8});
		_checkbox9.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox9});
		_checkbox10.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox10});
		_checkbox11.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox11});
		_checkbox12.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox12});
		_checkbox13.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox13});
		_checkbox14.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox14});
		_checkbox15.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox15});
		_checkbox16.Connect("pressed",this,nameof(CheckBoxPressed),new Godot.Collections.Array { _checkbox16});
		
		_lineEdit1 = GetNode<LineEdit>("Sound1/LineEdit");
		_lineEdit2 = GetNode<LineEdit>("Sound2/LineEdit");
		_lineEdit3 = GetNode<LineEdit>("Sound3/LineEdit");
		_lineEdit4 = GetNode<LineEdit>("Sound4/LineEdit");
		_lineEdit5 = GetNode<LineEdit>("Sound5/LineEdit");
		_lineEdit6 = GetNode<LineEdit>("Sound6/LineEdit");
		_lineEdit7 = GetNode<LineEdit>("Sound7/LineEdit");
		_lineEdit8 = GetNode<LineEdit>("Sound8/LineEdit");
		_lineEdit9 = GetNode<LineEdit>("Sound9/LineEdit");
		_lineEdit10 = GetNode<LineEdit>("Sound10/LineEdit");
		_lineEdit11 = GetNode<LineEdit>("Sound11/LineEdit");
		_lineEdit12 = GetNode<LineEdit>("Sound12/LineEdit");
		_lineEdit13 = GetNode<LineEdit>("Sound13/LineEdit");
		_lineEdit14 = GetNode<LineEdit>("Sound14/LineEdit");
		_lineEdit15 = GetNode<LineEdit>("Sound15/LineEdit");
		_lineEdit16 = GetNode<LineEdit>("Sound16/LineEdit");
		
		
		_editName1 = GetNode<TextureButton>("Sound1/EditName");
		_editName2 = GetNode<TextureButton>("Sound2/EditName");
		_editName3 = GetNode<TextureButton>("Sound3/EditName");
		_editName4 = GetNode<TextureButton>("Sound4/EditName");
		_editName5 = GetNode<TextureButton>("Sound5/EditName");
		_editName6 = GetNode<TextureButton>("Sound6/EditName");
		_editName7 = GetNode<TextureButton>("Sound7/EditName");
		_editName8 = GetNode<TextureButton>("Sound8/EditName");
		_editName9 = GetNode<TextureButton>("Sound9/EditName");
		_editName10 = GetNode<TextureButton>("Sound10/EditName");
		_editName11 = GetNode<TextureButton>("Sound11/EditName");
		_editName12 = GetNode<TextureButton>("Sound12/EditName");
		_editName13 = GetNode<TextureButton>("Sound13/EditName");
		_editName14 = GetNode<TextureButton>("Sound14/EditName");
		_editName15 = GetNode<TextureButton>("Sound15/EditName");
		_editName16 = GetNode<TextureButton>("Sound16/EditName");
		
		_editName1.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit1});
		_editName2.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit2});
		_editName3.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit3});
		_editName4.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit4});
		_editName5.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit5});
		_editName6.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit6});
		_editName7.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit7});
		_editName8.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit8});
		_editName9.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit9});
		_editName10.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit10});
		_editName11.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit11});
		_editName12.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit12});
		_editName13.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit13});
		_editName14.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit14});
		_editName15.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit15});
		_editName16.Connect("pressed",this,nameof(EditName),new Godot.Collections.Array { _lineEdit16});

		

		
		
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
		_lineEdit1.Text = _sound.lineEdit1;
		_lineEdit2.Text = _sound.lineEdit2;
		_lineEdit3.Text = _sound.lineEdit3;
		_lineEdit4.Text = _sound.lineEdit4;
		_lineEdit5.Text = _sound.lineEdit5;
		_lineEdit6.Text = _sound.lineEdit6;
		_lineEdit7.Text = _sound.lineEdit7;
		_lineEdit8.Text = _sound.lineEdit8;
		_lineEdit9.Text = _sound.lineEdit9;
		_lineEdit10.Text = _sound.lineEdit10;
		_lineEdit11.Text = _sound.lineEdit11;
		_lineEdit12.Text = _sound.lineEdit12;
		_lineEdit13.Text = _sound.lineEdit13;
		_lineEdit14.Text = _sound.lineEdit14;
		_lineEdit15.Text = _sound.lineEdit15;
		_lineEdit16.Text = _sound.lineEdit16;
		
		UpdateLineEdit();
	}

	public void EditName(LineEdit _lineEdit)
	{
		lineEditCopy = _lineEdit;
		_lineEdit.SetMouseFilter(Control.MouseFilterEnum.Stop);
		_lineEdit.Editable = true;
		GD.Print(_lineEdit.Editable);
		GD.Print(_lineEdit);
		_lineEdit.GrabFocus();
		_lineEdit.CaretPosition = _lineEdit.Text.Length;
		//_dragAndDropSound.ChangeText(name);
	}
	public void CheckBoxPressed(TextureButton checkbox)
	{
		if (checkbox.TextureNormal == checkBoxPressed && Visible == true)
		{
			
			alreadyChecked = true;
		}
		else
		{
			_checkbox1.TextureNormal = checkBox;
			_checkbox2.TextureNormal = checkBox;
			_checkbox3.TextureNormal = checkBox;
			_checkbox4.TextureNormal = checkBox;
			_checkbox5.TextureNormal = checkBox;
			_checkbox6.TextureNormal = checkBox;
			_checkbox7.TextureNormal = checkBox;
			_checkbox8.TextureNormal = checkBox;
			_checkbox9.TextureNormal = checkBox;
			_checkbox10.TextureNormal = checkBox;
			_checkbox11.TextureNormal = checkBox;
			_checkbox12.TextureNormal = checkBox;
			_checkbox13.TextureNormal = checkBox;
			_checkbox14.TextureNormal = checkBox;
			_checkbox15.TextureNormal = checkBox;
			_checkbox16.TextureNormal = checkBox;
		}

		if (alreadyChecked == true)
		{
			checkbox.TextureNormal = checkBox;
			currentlyChecked = null;
			SoundSelected();
			alreadyChecked = false;
		}
		else
		{
			currentlyChecked = checkbox.Name;
			checkbox.TextureNormal = checkBoxPressed;
			SoundSelected();
		}
	}

	public void SoundSelected()
	{
		if (currentlyChecked == "CheckBox1")
		{
			soundIsSelected = true;
			currentName = _lineEdit1.Text;
			currentlyChecked = "Sound1";
		}
		if (currentlyChecked == "CheckBox2")
		{
			soundIsSelected  = true;
			currentName = _lineEdit2.Text;
			currentlyChecked = "Sound2";
		}
		if (currentlyChecked == "CheckBox3")
		{
			soundIsSelected = true;
			currentName = _lineEdit3.Text;
			currentlyChecked = "Sound3";
		}
		if (currentlyChecked == "CheckBox4")
		{
			soundIsSelected = true;
			currentName = _lineEdit4.Text;
			currentlyChecked = "Sound4";
		}
		if (currentlyChecked == "CheckBox5")
		{
			soundIsSelected = true;
			currentName = _lineEdit5.Text;
			currentlyChecked = "Sound5";
		}
		if (currentlyChecked == "CheckBox6")
		{
			soundIsSelected = true;
			currentName = _lineEdit6.Text;
			currentlyChecked = "Sound6";
		}
		if (currentlyChecked == "CheckBox7")
		{
			soundIsSelected = true;
			currentName = _lineEdit7.Text;
			currentlyChecked = "Sound7";
		}
		if (currentlyChecked == "CheckBox8")
		{
			soundIsSelected = true;
			currentName = _lineEdit8.Text;
			currentlyChecked = "Sound8";
			
		}
		if (currentlyChecked == "CheckBox9")
		{
			soundIsSelected = true;
			currentName = _lineEdit9.Text;
			currentlyChecked = "Sound9";
		}
		if (currentlyChecked == "CheckBox10")
		{
			soundIsSelected = true;
			currentName = _lineEdit10.Text;
			currentlyChecked = "Sound10";
		}
		if (currentlyChecked == "CheckBox11")
		{
			soundIsSelected = true;
			currentName = _lineEdit11.Text;
			currentlyChecked = "Sound11";
		}
		if (currentlyChecked == "CheckBox12")
		{
			soundIsSelected = true;
			currentName = _lineEdit12.Text;
			currentlyChecked = "Sound12";
		}
		if (currentlyChecked == "CheckBox13")
		{
			soundIsSelected = true;
			currentName = _lineEdit13.Text;
			currentlyChecked = "Sound13";
		}
		if (currentlyChecked == "CheckBox14")
		{
			soundIsSelected = true;
			currentName = _lineEdit14.Text;
			currentlyChecked = "Sound14";
		}
		if (currentlyChecked == "CheckBox15")
		{
			soundIsSelected = true;
			currentName = _lineEdit15.Text;
			currentlyChecked = "Sound15";
		}
		if (currentlyChecked == "CheckBox16")
		{
			soundIsSelected = true;
			currentName = _lineEdit16.Text;
			currentlyChecked = "Sound16";
		}
		if (soundIsSelected )
		{
			_selectedSound.Text = currentName;
			_selectedSound.Visible = true;
			soundIsSelected  = false;
		}
		else
		{
			_selectedSound.Text = currentName;
			_selectedSound.Visible = false;
		}
	}

	public void CheckCorrect()
	{
		
		if (_soundSlider != null)
		{
			_soundSlider.CheckCorrect(currentlyChecked);
			_soundSlider2.CheckCorrect(currentlyChecked);
			_soundSlider3.CheckCorrect(currentlyChecked);
			_soundSlider4.CheckCorrect(currentlyChecked);
			_soundSlider5.CheckCorrect(currentlyChecked);
			_soundSlider6.CheckCorrect(currentlyChecked);
			_soundSlider7.CheckCorrect(currentlyChecked);
			_soundSlider8.CheckCorrect(currentlyChecked);
			_soundSlider9.CheckCorrect(currentlyChecked);
		}
		
	}


	public void ThisPressed(TextureButton tab)
	{
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
			
			
			//_checkbox3.Visible = true;
			//_checkbox4.Visible = true;

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

			//_checkbox5.Visible = true;
			//_checkbox6.Visible = true;
			//_checkbox7.Visible = true;
			//_checkbox8.Visible = true;
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
	
	private void _on_CheckBox_toggled(bool button_pressed)
	{
		GD.Print(button_pressed);
		if (_checkbox1.Pressed)
		{
			GD.Print("uwu");
			_checkbox2.Pressed = false;
		}
		else if (_checkbox2.Pressed)
		{
			GD.Print("owo");
			_checkbox1.Pressed = false;
		}
	}
	
	private void _on_LineEdit_text_changed(String new_text)
	{
		// Replace with function body.
	}
	private void _on_LineEdit_text_entered(String new_text)
	{
		lineEditCopy.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		lineEditCopy.Editable = false;
		if (lineEditCopy == _lineEdit1)
		{
			_sound.lineEdit1 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit2)
		{
			_sound.lineEdit2 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit3)
		{
			_sound.lineEdit3 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit4)
		{
			_sound.lineEdit4 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit5)
		{
			_sound.lineEdit5 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit6)
		{
			_sound.lineEdit6 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit7)
		{
			_sound.lineEdit7 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit8)
		{
			_sound.lineEdit8 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit9)
		{
			_sound.lineEdit9 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit10)
		{
			_sound.lineEdit10 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit11)
		{
			_sound.lineEdit11 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit12)
		{
			_sound.lineEdit12 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit13)
		{
			_sound.lineEdit13 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit14)
		{
			_sound.lineEdit14 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit15)
		{
			_sound.lineEdit15 = lineEditCopy.Text;
		}
		if (lineEditCopy == _lineEdit16)
		{
			_sound.lineEdit16 = lineEditCopy.Text;
		}
			
		UpdateLineEdit();
	}

	public void UpdateLineEdit()
	{
		_lineEdit1.Text = _sound.lineEdit1;
		_lineEdit2.Text = _sound.lineEdit2;
		_lineEdit3.Text = _sound.lineEdit3;
		_lineEdit4.Text = _sound.lineEdit4;
		_lineEdit5.Text = _sound.lineEdit5;
		_lineEdit6.Text = _sound.lineEdit6;
		_lineEdit7.Text = _sound.lineEdit7;
		_lineEdit8.Text = _sound.lineEdit8;
		_lineEdit9.Text = _sound.lineEdit9;
		_lineEdit10.Text = _sound.lineEdit10;
		_lineEdit11.Text = _sound.lineEdit11;
		_lineEdit12.Text = _sound.lineEdit12;
		_lineEdit13.Text = _sound.lineEdit13;
		_lineEdit14.Text = _sound.lineEdit14;
		_lineEdit15.Text = _sound.lineEdit15;
		_lineEdit16.Text = _sound.lineEdit16;
	}
}
























