using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using iText.IO.Font.Otf.Lookuptype5;
using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Splitting;

namespace GetOn.scenes.Narrative
{
	public class CheckCorrect : Area2D
	{
		private SharedNode _sharedNode;
		private DragAndDropStory _dragAndDropStory;
			
		//Story 1 
		private bool endingPerfect;
		private bool endingOk;
		private bool settingCorrect;
		private bool ending3;
		private int points;
		private Button _submit;
		private Label _attribute1;
		private Label _attribute2;
		private Label _attribute3;
		private Label _attribute4;

		private List<int> correctAttributesKriv = new List<int> { 1, 2, 3, 4 };
		private List<int> correctAttributesAshe = new List<int> { 2, 4, 5, 6 };

		private List<int> correctAttributesEndingTigress1 = new List<int> {14,17,1,3 };
		private List<int> correctAttributesEndingTigress2 = new List<int> {6,12,14,3 };
		private List<int> correctAttributesEndingTigress3 = new List<int> {10,11,13,5};
		
		private List<int> correctAttributesEndingHound1 = new List<int> {1,12,4,2};
		private List<int> correctAttributesEndingHound2 = new List<int> {17,13,4,2};
		private List<int> correctAttributesEndingHound3 = new List<int> {10,7,8,9};
		
		private List<int> correctAttributesEndingJohn1 = new List<int> {13,2,17,12 };
		private List<int> correctAttributesEndingJohn2 = new List<int> {5,16,8,7 };
		private List<int> correctAttributesEndingJohn3 = new List<int> {14,17,6,4 };
		
		private List<int> correctAttributesEndingClaire1 = new List<int> {6,3,2,9 };
		private List<int> correctAttributesEndingClaire2 = new List<int> {14,3,4,15 };
		private List<int> correctAttributesEndingClaire3 = new List<int> { 4,6,3,1};
		
		private bool indexCorrect1 = false;
		private bool indexCorrect2 = false;
		private bool indexCorrect3 = false;
		private bool indexCorrect4 = false;
		private bool indexCorrect5 = false;
		private bool indexCorrect6 = false;
		private bool indexCorrect7 = false;
		private bool indexCorrect8 = false;
		private int indexCopy1 = 0;
		private int indexCopy2 = 0;
		private int indexCopy3 = 0;
		private int indexCopy4 = 0;
		private int indexCopy5 = 0;
		private int indexCopy6 = 0;
		private int indexCopy7 = 0;
		private int indexCopy8 = 0;

		//Story 2
		private bool endingPerfect2;
		private bool endingOk2;
		private bool ending23;
		private bool settingCorrect2;

		private List<int> correctAttributesJim = new List<int> { 11, 8, 9, 10 };
		private List<int> correctAttributesEmilia = new List<int> { 8, 12, 11, 10 };

		private bool indexCorrect21 = false;
		private bool indexCorrect22 = false;
		private bool indexCorrect23 = false;
		private bool indexCorrect24 = false;
		private bool indexCorrect25 = false;
		private bool indexCorrect26 = false;
		private bool indexCorrect27 = false;
		private bool indexCorrect28 = false;
		private int indexCopy21 = 0;
		private int indexCopy22 = 0;
		private int indexCopy23 = 0;
		private int indexCopy24 = 0;
		private int indexCopy25 = 0;
		private int indexCopy26 = 0;
		private int indexCopy27 = 0;
		private int indexCopy28 = 0;

		//Story3
		private bool endingPerfect3;
		private bool endingOk3;
		private bool settingCorrect3;

		private List<int> correctAttributesNora = new List<int> { 2, 6, 13, 4 };
		private List<int> correctAttributesAnne = new List<int> { 9, 14, 10, 4 };

		private bool indexCorrect31 = false;
		private bool indexCorrect32 = false;
		private bool indexCorrect33 = false;
		private bool indexCorrect34 = false;
		private bool indexCorrect35 = false;
		private bool indexCorrect36 = false;
		private bool indexCorrect37 = false;
		private bool indexCorrect38 = false;
		private int indexCopy31 = 0;
		private int indexCopy32 = 0;
		private int indexCopy33 = 0;
		private int indexCopy34 = 0;
		private int indexCopy35 = 0;
		private int indexCopy36 = 0;
		private int indexCopy37 = 0;
		private int indexCopy38 = 0;


		private Node2D _part1;
		private Node2D _part2;

		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_dragAndDropStory = GetNode<DragAndDropStory>("/root/Narrative/1/Ending1");
			endingPerfect = false;
			endingOk = false;
			settingCorrect = false;
			points = 0;
			_submit = GetNode<Button>("/root/Narrative/Submit");
			_submit.Connect("pressed", this, nameof(CountPoints));
			_attribute1 = GetNode<Label>("/root/Narrative/1/Attribute");
			_attribute2 = GetNode<Label>("/root/Narrative/1/Attribute2");
			_attribute3 = GetNode<Label>("/root/Narrative/2/Attribute");
			_attribute4 = GetNode<Label>("/root/Narrative/2/Attribute2");
			_attribute1.Text = "";
			_attribute2.Text = "";
			_attribute3.Text = "";
			_attribute4.Text = "";

			_part1 = GetNode<Node2D>("/root/Narrative/1");
			_part2 = GetNode<Node2D>("/root/Narrative/2");
		}

		//Check if correct ending entered 

		private void _on_CheckCorrect_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Ending1")
				{
					endingPerfect = true;
				}
				else if (kinematicBody.Name == "Ending2")
				{
					endingOk = true;
				}
				else if (kinematicBody.Name == "Ending3")
				{
					ending3 = true;
				}
				else if (kinematicBody.Name == "Ending21")
				{
					endingPerfect2 = true;
				}
				else if (kinematicBody.Name == "Ending22")
				{
					endingOk2 = true;
				}
				else if (kinematicBody.Name == "Ending23")
				{
					ending23 = true;
				}

			}
			Reset();
			ChangeLabel();
		}

		private void _on_CheckCorrect_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Ending1")
				{
					endingPerfect = false;
					GD.Print(endingPerfect);

				}
				else if (kinematicBody.Name == "Ending2")
				{
					endingOk = false;
					GD.Print(endingOk);

				}
				else if (kinematicBody.Name == "Ending3")
				{
					ending3 = false;
				}
				else if (kinematicBody.Name == "Ending21")
				{
					endingPerfect2 = false;
				}
				else if (kinematicBody.Name == "Ending22")
				{
					endingOk2 = false;
				}
				else if (kinematicBody.Name == "Ending23")
				{
					ending23 = false;
				}
			}
			Reset();
			ChangeLabel();
		}

		private void ChangeLabel()
		{
			if (endingPerfect)
			{
				_attribute1.Text = "Development";
				_attribute2.Text = "Development";
			}
			else if (endingOk)
			{
				_attribute1.Text = "Development";
				_attribute2.Text = "Development";
			}
			else if (ending3)
			{
				_attribute1.Text = "Degeneration";
				_attribute2.Text = "Doesn´t Change";
			}
			else if (endingPerfect2)
			{
				_attribute3.Text = "Mixed";
				_attribute4.Text = "Stays the same";
			}
			else if (endingOk2)
			{
				_attribute3.Text = "Degeneration";
				_attribute4.Text = "Stays the same";
			}
			else if (ending23)
			{
				_attribute3.Text = "Development";
				_attribute4.Text = "Development";
			}
			else
			{
				_attribute1.Text = "";
				_attribute2.Text = "";
				_attribute3.Text = "";
				_attribute4.Text = "";
			}
		}

		private void Reset()
		{
			if (_part1.Visible == true)
			{
				correctAttributesEndingTigress1 = new List<int> { 14,17,1,3};
				correctAttributesEndingTigress2 = new List<int> {6,12,14,3 };
				correctAttributesEndingTigress3 = new List<int> {10,11,13,5};
			
				correctAttributesEndingHound1 = new List<int> {1,12,4,2};
				correctAttributesEndingHound2 = new List<int> {17,13,4,2};
				correctAttributesEndingHound3 = new List<int> {10,7,8,9};
				
				indexCorrect1 = false;
				indexCorrect2 = false;
				indexCorrect3 = false;
				indexCorrect4 = false;

				indexCorrect5 = false;
				indexCorrect6 = false;
				indexCorrect7 = false;
				indexCorrect8 = false;
				
				_dragAndDropStory.ResetInputs(1);
			}
			else
			{
				correctAttributesEndingJohn1 = new List<int> {13,2,17,12 };
				correctAttributesEndingJohn2 = new List<int> {5,16,8,7 };
				correctAttributesEndingJohn3 = new List<int> {14,17,6,4 };
			
				correctAttributesEndingClaire1 = new List<int> {6,3,2,9 };
				correctAttributesEndingClaire2 = new List<int> {14,3,4,15 };
				correctAttributesEndingClaire3 = new List<int> { 4,6,3,1};
				
				indexCorrect21 = false;
				indexCorrect22 = false;
				indexCorrect23 = false;
				indexCorrect24 = false;
			
				indexCorrect25 = false;
				indexCorrect26 = false;
				indexCorrect27 = false;
				indexCorrect28 = false;
				
				_dragAndDropStory.ResetInputs(2);
			}
			
			
			

			

		}

		//First Story

		private void _on_DropDownSetting_item_selected(int index)
		{
			if (index == 1)
			{
				settingCorrect = true;
			}
			else
			{
				settingCorrect = false;
			}
		}

		private void _on_DropDownAttribute1_item_selected(int index)
		{
			/*
			if (endingPerfect)
			{
				if (indexCorrect1 == false)
				{
					switch (index)
					{
						case 1:
							correctAttributesEndingTigress1.Remove(1);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
						case 3:
							correctAttributesEndingTigress1.Remove(3);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
						case 14:
							correctAttributesEndingTigress1.Remove(14);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
						case 17:
							correctAttributesEndingTigress1.Remove(17);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
					}
					GD.Print(correctAttributesEndingTigress1.Count);
					for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
					{
						GD.Print(correctAttributesEndingTigress1[i]);
					}
				}
				else if(correctAttributesEndingTigress1.Count <4)
				{
					switch (indexCopy1)
					{
						case 1:
							correctAttributesEndingTigress1.Add(1);
							indexCopy1 = index;
							indexCorrect1 = false;
							break;
						case 3:
							correctAttributesEndingTigress1.Add(3);
							indexCopy1 = index;
							indexCorrect1 = false;
							break;
						case 14:
							correctAttributesEndingTigress1.Add(14);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
						case 17:
							correctAttributesEndingTigress1.Add(17);
							indexCopy1 = index;
							indexCorrect1 = true;
							break;
					}

					if (correctAttributesEndingTigress1.Contains(index))
					{
						switch (index)
						{
							case 1:
								correctAttributesEndingTigress1.Remove(1);
								indexCopy1 = index;
								indexCorrect1 = true;
								break;
							case 3:
								correctAttributesEndingTigress1.Remove(3);
								indexCopy1 = index;
								indexCorrect1 = true;
								break;
							case 14:
								correctAttributesEndingTigress1.Remove(14);
								indexCopy1 = index;
								indexCorrect1 = true;
								break;
							case 17:
								correctAttributesEndingTigress1.Remove(17);
								indexCopy1 = index;
								indexCorrect1 = true;
								break;
						}
					}
					
					
					GD.Print(correctAttributesEndingTigress1.Count);
					for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
					{
						GD.Print(correctAttributesEndingTigress1[i]);
					}
				}
					
			}
			*/
			
			
			if (endingPerfect)
			{
				
				if (correctAttributesEndingTigress1.Contains(index) && indexCorrect1 == false)
				{
					GD.Print("test #1");
					correctAttributesEndingTigress1.Remove(index);
					indexCopy1 = index;
					indexCorrect1 = true;

				}
				else if (indexCorrect1 && correctAttributesEndingTigress1.Count <4)
				{
					GD.Print("test #2");
					correctAttributesEndingTigress1.Add(indexCopy1);
					indexCorrect1 = false;
					indexCopy1 = index;

					if (correctAttributesEndingTigress1.Contains(index))
					{
						correctAttributesEndingTigress1.Remove(index);
						indexCorrect1 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress1.Count);
				for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingTigress2.Contains(index) && indexCorrect1 == false)
				{
					correctAttributesEndingTigress2.Remove(index);
					indexCopy1 = index;
					indexCorrect1 = true;

				}
				else if (indexCorrect1 && correctAttributesEndingTigress2.Count <4)
				{
					correctAttributesEndingTigress2.Add(indexCopy1);
					indexCorrect1 = false;
					indexCopy1 = index;

					if (correctAttributesEndingTigress2.Contains(index))
					{
						correctAttributesEndingTigress2.Remove(index);
						indexCorrect1 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress2.Count);
				for(int i=0; i<correctAttributesEndingTigress2.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingTigress3.Contains(index) && indexCorrect1 == false)
				{
					correctAttributesEndingTigress3.Remove(index);
					indexCopy1 = index;
					indexCorrect1 = true;

				}
				else if (indexCorrect1 && correctAttributesEndingTigress3.Count <4)
				{
					correctAttributesEndingTigress3.Add(indexCopy1);
					indexCorrect1 = false;
					indexCopy1 = index;

					if (correctAttributesEndingTigress3.Contains(index))
					{
						correctAttributesEndingTigress3.Remove(index);
						indexCorrect1 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress3.Count);
				for(int i=0; i<correctAttributesEndingTigress3.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress3[i]);
				}
			}
			
		}

		private void _on_DropDownAttribute2_item_selected(int index)
		{
			if (endingPerfect)
			{
				if (correctAttributesEndingTigress1.Contains(index) && indexCorrect2 == false)
				{
					correctAttributesEndingTigress1.Remove(index);
					indexCopy2 = index;
					indexCorrect2 = true;
				}
				else if (indexCorrect2 && correctAttributesEndingTigress1.Count <4)
				{
					correctAttributesEndingTigress1.Add(indexCopy2);
					indexCorrect2 = false;
					indexCopy2 = index;
					if (correctAttributesEndingTigress1.Contains(index))
					{
						correctAttributesEndingTigress1.Remove(index);
						indexCorrect2 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress1.Count);
				for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress1[i]);
				}
				
			}
			else if(endingOk)
			{
				
				if (correctAttributesEndingTigress2.Contains(index) && indexCorrect2 == false)
				{
					correctAttributesEndingTigress2.Remove(index);
					indexCopy2 = index;
					indexCorrect2 = true;

				}
				else if (indexCorrect2 && correctAttributesEndingTigress2.Count <4)
				{
					correctAttributesEndingTigress2.Add(indexCopy2);
					indexCorrect2= false;
					indexCopy2 = index;

					if (correctAttributesEndingTigress2.Contains(index))
					{
						correctAttributesEndingTigress2.Remove(index);
						indexCorrect2 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress2.Count);
				for(int i=0; i<correctAttributesEndingTigress2.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingTigress3.Contains(index) && indexCorrect2 == false)
				{
					correctAttributesEndingTigress3.Remove(index);
					indexCopy2 = index;
					indexCorrect2 = true;

				}
				else if (indexCorrect2 && correctAttributesEndingTigress3.Count <4)
				{
					correctAttributesEndingTigress3.Add(indexCopy2);
					indexCorrect2 = false;
					indexCopy2 = index;

					if (correctAttributesEndingTigress3.Contains(index))
					{
						correctAttributesEndingTigress3.Remove(index);
						indexCorrect2 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress3.Count);
				for(int i=0; i<correctAttributesEndingTigress3.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress3[i]);
				}
			}
		}


		private void _on_DropDownAttribute3_item_selected(int index)
		{
			if (endingPerfect)
			{

				if (correctAttributesEndingTigress1.Contains(index) && indexCorrect3 == false)
				{
					correctAttributesEndingTigress1.Remove(index);
					indexCopy3 = index;
					indexCorrect3 = true;

				}
				else if (indexCorrect3 && correctAttributesEndingTigress1.Count <4)
				{
					correctAttributesEndingTigress1.Add(indexCopy3);
					indexCorrect3 = false;
					indexCopy3 = index;

					if (correctAttributesEndingTigress1.Contains(index))
					{
						correctAttributesEndingTigress1.Remove(index);
						indexCorrect3 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress1.Count);
				for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingTigress2.Contains(index) && indexCorrect3 == false)
				{
					correctAttributesEndingTigress2.Remove(index);
					indexCopy3 = index;
					indexCorrect3 = true;

				}
				else if (indexCorrect3 && correctAttributesEndingTigress2.Count <4)
				{
					correctAttributesEndingTigress2.Add(indexCopy3);
					indexCorrect3 = false;
					indexCopy3 = index;

					if (correctAttributesEndingTigress2.Contains(index))
					{
						correctAttributesEndingTigress2.Remove(index);
						indexCorrect3 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress2.Count);
				for(int i=0; i<correctAttributesEndingTigress2.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingTigress3.Contains(index) && indexCorrect3 == false)
				{
					correctAttributesEndingTigress3.Remove(index);
					indexCopy3 = index;
					indexCorrect3 = true;

				}
				else if (indexCorrect3 && correctAttributesEndingTigress3.Count <4)
				{
					correctAttributesEndingTigress3.Add(indexCopy3);
					indexCorrect3 = false;
					indexCopy3 = index;

					if (correctAttributesEndingTigress3.Contains(index))
					{
						correctAttributesEndingTigress3.Remove(index);
						indexCorrect3 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress3.Count);
				for(int i=0; i<correctAttributesEndingTigress3.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress3[i]);
				}
			}
		}


		private void _on_DropDownAttribute4_item_selected(int index)
		{
			if (endingPerfect)
			{

				if (correctAttributesEndingTigress1.Contains(index) && indexCorrect4 == false)
				{
					correctAttributesEndingTigress1.Remove(index);
					indexCopy4 = index;
					indexCorrect4 = true;

				}
				else if (indexCorrect4 && correctAttributesEndingTigress1.Count <4)
				{
					correctAttributesEndingTigress1.Add(indexCopy4);
					indexCorrect4 = false;
					indexCopy4 = index;

					if (correctAttributesEndingTigress1.Contains(index))
					{
						correctAttributesEndingTigress1.Remove(index);
						indexCorrect4 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress1.Count);
				for(int i=0; i<correctAttributesEndingTigress1.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingTigress2.Contains(index) && indexCorrect4 == false)
				{
					correctAttributesEndingTigress2.Remove(index);
					indexCopy4 = index;
					indexCorrect4 = true;

				}
				else if (indexCorrect4 && correctAttributesEndingTigress2.Count <4)
				{
					correctAttributesEndingTigress2.Add(indexCopy4);
					indexCorrect4 = false;
					indexCopy4 = index;

					if (correctAttributesEndingTigress2.Contains(index))
					{
						correctAttributesEndingTigress2.Remove(index);
						indexCorrect4 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress2.Count);
				for(int i=0; i<correctAttributesEndingTigress2.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingTigress3.Contains(index) && indexCorrect4 == false)
				{
					correctAttributesEndingTigress3.Remove(index);
					indexCopy4 = index;
					indexCorrect4 = true;

				}
				else if (indexCorrect4 && correctAttributesEndingTigress3.Count <4)
				{
					correctAttributesEndingTigress3.Add(indexCopy4);
					indexCorrect4 = false;
					indexCopy4 = index;

					if (correctAttributesEndingTigress3.Contains(index))
					{
						correctAttributesEndingTigress3.Remove(index);
						indexCorrect4 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingTigress3.Count);
				for(int i=0; i<correctAttributesEndingTigress3.Count; i++)
				{
					GD.Print(correctAttributesEndingTigress3[i]);
				}
			}
		}

		private void _on_DropDownAttribute5_item_selected(int index)
		{
			if (endingPerfect)
			{
				
				if (correctAttributesEndingHound1.Contains(index) && indexCorrect5 == false)
				{
					correctAttributesEndingHound1.Remove(index);
					indexCopy5 = index;
					indexCorrect5 = true;

				}
				else if (indexCorrect5 && correctAttributesEndingHound1.Count <4)
				{
					correctAttributesEndingHound1.Add(indexCopy5);
					indexCorrect5 = false;
					indexCopy5 = index;

					if (correctAttributesEndingHound1.Contains(index))
					{
						correctAttributesEndingHound1.Remove(index);
						indexCorrect5 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound1.Count);
				for(int i=0; i<correctAttributesEndingHound1.Count; i++)
				{
					GD.Print(correctAttributesEndingHound1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingHound2.Contains(index) && indexCorrect5 == false)
				{
					correctAttributesEndingHound2.Remove(index);
					indexCopy5 = index;
					indexCorrect5 = true;

				}
				else if (indexCorrect5 && correctAttributesEndingHound2.Count <4)
				{
					correctAttributesEndingHound2.Add(indexCopy5);
					indexCorrect5 = false;
					indexCopy5 = index;

					if (correctAttributesEndingHound2.Contains(index))
					{
						correctAttributesEndingHound2.Remove(index);
						indexCorrect5 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound2.Count);
				for(int i=0; i<correctAttributesEndingHound2.Count; i++)
				{
					GD.Print(correctAttributesEndingHound2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingHound3.Contains(index) && indexCorrect5 == false)
				{
					correctAttributesEndingHound3.Remove(index);
					indexCopy5 = index;
					indexCorrect5 = true;

				}
				else if (indexCorrect5 && correctAttributesEndingHound3.Count <4)
				{
					correctAttributesEndingHound3.Add(indexCopy5);
					indexCorrect5 = false;
					indexCopy5 = index;

					if (correctAttributesEndingHound3.Contains(index))
					{
						correctAttributesEndingHound3.Remove(index);
						indexCorrect5 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound3.Count);
				for(int i=0; i<correctAttributesEndingHound3.Count; i++)
				{
					GD.Print(correctAttributesEndingHound3[i]);
				}
			}
		}


		private void _on_DropDownAttribute6_item_selected(int index)
		{
			if (endingPerfect)
			{
				
				if (correctAttributesEndingHound1.Contains(index) && indexCorrect6 == false)
				{
					correctAttributesEndingHound1.Remove(index);
					indexCopy6 = index;
					indexCorrect6 = true;

				}
				else if (indexCorrect6 && correctAttributesEndingHound1.Count <4)
				{
					correctAttributesEndingHound1.Add(indexCopy6);
					indexCorrect6 = false;
					indexCopy6 = index;

					if (correctAttributesEndingHound1.Contains(index))
					{
						correctAttributesEndingHound1.Remove(index);
						indexCorrect6 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound1.Count);
				for(int i=0; i<correctAttributesEndingHound1.Count; i++)
				{
					GD.Print(correctAttributesEndingHound1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingHound2.Contains(index) && indexCorrect6 == false)
				{
					correctAttributesEndingHound2.Remove(index);
					indexCopy6 = index;
					indexCorrect6 = true;

				}
				else if (indexCorrect6 && correctAttributesEndingHound2.Count <4)
				{
					correctAttributesEndingHound2.Add(indexCopy6);
					indexCorrect6 = false;
					indexCopy6 = index;

					if (correctAttributesEndingHound2.Contains(index))
					{
						correctAttributesEndingHound2.Remove(index);
						indexCorrect6 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound2.Count);
				for(int i=0; i<correctAttributesEndingHound2.Count; i++)
				{
					GD.Print(correctAttributesEndingHound2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingHound3.Contains(index) && indexCorrect6 == false)
				{
					correctAttributesEndingHound3.Remove(index);
					indexCopy6 = index;
					indexCorrect6 = true;

				}
				else if (indexCorrect6 && correctAttributesEndingHound3.Count <4)
				{
					correctAttributesEndingHound3.Add(indexCopy6);
					indexCorrect6 = false;
					indexCopy6 = index;

					if (correctAttributesEndingHound3.Contains(index))
					{
						correctAttributesEndingHound3.Remove(index);
						indexCorrect6 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound3.Count);
				for(int i=0; i<correctAttributesEndingHound3.Count; i++)
				{
					GD.Print(correctAttributesEndingHound3[i]);
				}
			}
		}


		private void _on_DropDownAttribute7_item_selected(int index)
		{ 
			if (endingPerfect)
			{
				
				if (correctAttributesEndingHound1.Contains(index) && indexCorrect7 == false)
				{
					correctAttributesEndingHound1.Remove(index);
					indexCopy7 = index;
					indexCorrect7 = true;

				}
				else if (indexCorrect7 && correctAttributesEndingHound1.Count <4)
				{
					correctAttributesEndingHound1.Add(indexCopy7);
					indexCorrect7 = false;
					indexCopy7 = index;

					if (correctAttributesEndingHound1.Contains(index))
					{
						correctAttributesEndingHound1.Remove(index);
						indexCorrect7 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound1.Count);
				for(int i=0; i<correctAttributesEndingHound1.Count; i++)
				{
					GD.Print(correctAttributesEndingHound1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingHound2.Contains(index) && indexCorrect7 == false)
				{
					correctAttributesEndingHound2.Remove(index);
					indexCopy7 = index;
					indexCorrect7=true;

				}
				else if (indexCorrect7 && correctAttributesEndingHound2.Count <4)
				{
					correctAttributesEndingHound2.Add(indexCopy7);
					indexCorrect7 = false;
					indexCopy7 = index;

					if (correctAttributesEndingHound2.Contains(index))
					{
						correctAttributesEndingHound2.Remove(index);
						indexCorrect7 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound2.Count);
				for(int i=0; i<correctAttributesEndingHound2.Count; i++)
				{
					GD.Print(correctAttributesEndingHound2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingHound3.Contains(index) && indexCorrect7 == false)
				{
					correctAttributesEndingHound3.Remove(index);
					indexCopy7 = index;
					indexCorrect7 = true;

				}
				else if (indexCorrect7 && correctAttributesEndingHound3.Count <4)
				{
					correctAttributesEndingHound3.Add(indexCopy7);
					indexCorrect7 = false;
					indexCopy7 = index;

					if (correctAttributesEndingHound3.Contains(index))
					{
						correctAttributesEndingHound3.Remove(index);
						indexCorrect7 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound3.Count);
				for(int i=0; i<correctAttributesEndingHound3.Count; i++)
				{
					GD.Print(correctAttributesEndingHound3[i]);
				}
			}
		}


		private void _on_DropDownAttribute8_item_selected(int index)
		{
			if (endingPerfect)
			{
				
				if (correctAttributesEndingHound1.Contains(index) && indexCorrect8 == false)
				{
					correctAttributesEndingHound1.Remove(index);
					indexCopy8 = index;
					indexCorrect8 = true;

				}
				else if (indexCorrect8 && correctAttributesEndingHound1.Count <4)
				{
					correctAttributesEndingHound1.Add(indexCopy8);
					indexCorrect8 = false;
					indexCopy8 = index;

					if (correctAttributesEndingHound1.Contains(index))
					{
						correctAttributesEndingHound1.Remove(index);
						indexCorrect8 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound1.Count);
				for(int i=0; i<correctAttributesEndingHound1.Count; i++)
				{
					GD.Print(correctAttributesEndingHound1[i]);
				}
				
			}
			
			else if(endingOk)
			{
				
				if (correctAttributesEndingHound2.Contains(index) && indexCorrect8 == false)
				{
					correctAttributesEndingHound2.Remove(index);
					indexCopy8 = index;
					indexCorrect8=true;

				}
				else if (indexCorrect8 && correctAttributesEndingHound2.Count <4)
				{
					correctAttributesEndingHound2.Add(indexCopy8);
					indexCorrect8 = false;
					indexCopy8= index;

					if (correctAttributesEndingHound2.Contains(index))
					{
						correctAttributesEndingHound2.Remove(index);
						indexCorrect8 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound2.Count);
				for(int i=0; i<correctAttributesEndingHound2.Count; i++)
				{
					GD.Print(correctAttributesEndingHound2[i]);
				}
			}
			else if (ending3)
			{
				
				if (correctAttributesEndingHound3.Contains(index) && indexCorrect8 == false)
				{
					correctAttributesEndingHound3.Remove(index);
					indexCopy8 = index;
					indexCorrect8 = true;

				}
				else if (indexCorrect8 && correctAttributesEndingHound3.Count <4)
				{
					correctAttributesEndingHound3.Add(indexCopy8);
					indexCorrect8 = false;
					indexCopy8 = index;

					if (correctAttributesEndingHound3.Contains(index))
					{
						correctAttributesEndingHound3.Remove(index);
						indexCorrect8 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingHound3.Count);
				for(int i=0; i<correctAttributesEndingHound3.Count; i++)
				{
					GD.Print(correctAttributesEndingHound3[i]);
				}
			}
		}




		//Second Story

		private void _on_DropDownSetting2_item_selected(int index)
		{
			if (index == 4)
			{
				settingCorrect2 = true;
				GD.Print(settingCorrect2);
			}
			else
			{
				settingCorrect2 = false;
			}
		}

		private void _on_DropDownAttribute21_item_selected(int index)
		{ 
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingJohn1.Contains(index) && indexCorrect21 == false)
				{
					correctAttributesEndingJohn1.Remove(index);
					indexCopy21 = index;
					indexCorrect21 = true;

				}
				else if (indexCorrect21 && correctAttributesEndingJohn1.Count <4)
				{
					correctAttributesEndingJohn1.Add(indexCopy21);
					indexCorrect21 = false;
					indexCopy21 = index;

					if (correctAttributesEndingJohn1.Contains(index))
					{
						correctAttributesEndingJohn1.Remove(index);
						indexCorrect21 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn1.Count);
				for(int i=0; i<correctAttributesEndingJohn1.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingJohn2.Contains(index) && indexCorrect21 == false)
				{
					correctAttributesEndingJohn2.Remove(index);
					indexCopy21 = index;
					indexCorrect21 = true;

				}
				else if (indexCorrect21 && correctAttributesEndingJohn2.Count <4)
				{
					correctAttributesEndingJohn2.Add(indexCopy21);
					indexCorrect21 = false;
					indexCopy21 = index;

					if (correctAttributesEndingJohn2.Contains(index))
					{
						correctAttributesEndingJohn2.Remove(index);
						indexCorrect21 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn2.Count);
				for(int i=0; i<correctAttributesEndingJohn2.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingJohn3.Contains(index) && indexCorrect21 == false)
				{
					correctAttributesEndingJohn3.Remove(index);
					indexCopy21 = index;
					indexCorrect21 = true;

				}
				else if (indexCorrect21 && correctAttributesEndingJohn3.Count <4)
				{
					correctAttributesEndingJohn3.Add(indexCopy21);
					indexCorrect21 = false;
					indexCopy21 = index;

					if (correctAttributesEndingJohn3.Contains(index))
					{
						correctAttributesEndingJohn3.Remove(index);
						indexCorrect21 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn3.Count);
				for(int i=0; i<correctAttributesEndingJohn3.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn3[i]);
				}
			}
		}


		private void _on_DropDownAttribute22_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingJohn1.Contains(index) && indexCorrect22 == false)
				{
					correctAttributesEndingJohn1.Remove(index);
					indexCopy22 = index;
					indexCorrect22 = true;

				}
				else if (indexCorrect22 && correctAttributesEndingJohn1.Count <4)
				{
					correctAttributesEndingJohn1.Add(indexCopy22);
					indexCorrect22 = false;
					indexCopy22 = index;

					if (correctAttributesEndingJohn1.Contains(index))
					{
						correctAttributesEndingJohn1.Remove(index);
						indexCorrect22 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn1.Count);
				for(int i=0; i<correctAttributesEndingJohn1.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingJohn2.Contains(index) && indexCorrect22 == false)
				{
					correctAttributesEndingJohn2.Remove(index);
					indexCopy22 = index;
					indexCorrect22 = true;

				}
				else if (indexCorrect22 && correctAttributesEndingJohn2.Count <4)
				{
					correctAttributesEndingJohn2.Add(indexCopy22);
					indexCorrect22 = false;
					indexCopy22 = index;

					if (correctAttributesEndingJohn2.Contains(index))
					{
						correctAttributesEndingJohn2.Remove(index);
						indexCorrect22 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn2.Count);
				for(int i=0; i<correctAttributesEndingJohn2.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingJohn3.Contains(index) && indexCorrect22 == false)
				{
					correctAttributesEndingJohn3.Remove(index);
					indexCopy22 = index;
					indexCorrect22 = true;

				}
				else if (indexCorrect22 && correctAttributesEndingJohn3.Count <4)
				{
					correctAttributesEndingJohn3.Add(indexCopy22);
					indexCorrect22 = false;
					indexCopy22 = index;

					if (correctAttributesEndingJohn3.Contains(index))
					{
						correctAttributesEndingJohn3.Remove(index);
						indexCorrect22 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn3.Count);
				for(int i=0; i<correctAttributesEndingJohn3.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn3[i]);
				}
			}
		}


		private void _on_DropDownAttribute23_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingJohn1.Contains(index) && indexCorrect23 == false)
				{
					correctAttributesEndingJohn1.Remove(index);
					indexCopy23 = index;
					indexCorrect23 = true;

				}
				else if (indexCorrect23 && correctAttributesEndingJohn1.Count <4)
				{
					correctAttributesEndingJohn1.Add(indexCopy23);
					indexCorrect23 = false;
					indexCopy23 = index;

					if (correctAttributesEndingJohn1.Contains(index))
					{
						correctAttributesEndingJohn1.Remove(index);
						indexCorrect23 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn1.Count);
				for(int i=0; i<correctAttributesEndingJohn1.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingJohn2.Contains(index) && indexCorrect23 == false)
				{
					correctAttributesEndingJohn2.Remove(index);
					indexCopy23 = index;
					indexCorrect23 = true;

				}
				else if (indexCorrect23 && correctAttributesEndingJohn2.Count <4)
				{
					correctAttributesEndingJohn2.Add(indexCopy23);
					indexCorrect23 = false;
					indexCopy23 = index;

					if (correctAttributesEndingJohn2.Contains(index))
					{
						correctAttributesEndingJohn2.Remove(index);
						indexCorrect23 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn2.Count);
				for(int i=0; i<correctAttributesEndingJohn2.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingJohn3.Contains(index) && indexCorrect23 == false)
				{
					correctAttributesEndingJohn3.Remove(index);
					indexCopy23 = index;
					indexCorrect23 = true;

				}
				else if (indexCorrect23 && correctAttributesEndingJohn3.Count <4)
				{
					correctAttributesEndingJohn3.Add(indexCopy23);
					indexCorrect23 = false;
					indexCopy23 = index;

					if (correctAttributesEndingJohn3.Contains(index))
					{
						correctAttributesEndingJohn3.Remove(index);
						indexCorrect23 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn3.Count);
				for(int i=0; i<correctAttributesEndingJohn3.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn3[i]);
				}
			}
		}


		private void _on_DropDownAttribute24_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingJohn1.Contains(index) && indexCorrect24 == false)
				{
					correctAttributesEndingJohn1.Remove(index);
					indexCopy24 = index;
					indexCorrect24 = true;

				}
				else if (indexCorrect24 && correctAttributesEndingJohn1.Count <4)
				{
					correctAttributesEndingJohn1.Add(indexCopy24);
					indexCorrect24 = false;
					indexCopy24 = index;

					if (correctAttributesEndingJohn1.Contains(index))
					{
						correctAttributesEndingJohn1.Remove(index);
						indexCorrect24 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn1.Count);
				for(int i=0; i<correctAttributesEndingJohn1.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingJohn2.Contains(index) && indexCorrect24 == false)
				{
					correctAttributesEndingJohn2.Remove(index);
					indexCopy24 = index;
					indexCorrect24 = true;

				}
				else if (indexCorrect24 && correctAttributesEndingJohn2.Count <4)
				{
					correctAttributesEndingJohn2.Add(indexCopy24);
					indexCorrect24 = false;
					indexCopy24 = index;

					if (correctAttributesEndingJohn2.Contains(index))
					{
						correctAttributesEndingJohn2.Remove(index);
						indexCorrect24 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn2.Count);
				for(int i=0; i<correctAttributesEndingJohn2.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingJohn3.Contains(index) && indexCorrect24 == false)
				{
					correctAttributesEndingJohn3.Remove(index);
					indexCopy24 = index;
					indexCorrect24 = true;

				}
				else if (indexCorrect24 && correctAttributesEndingJohn3.Count <4)
				{
					correctAttributesEndingJohn3.Add(indexCopy24);
					indexCorrect24 = false;
					indexCopy24 = index;

					if (correctAttributesEndingJohn3.Contains(index))
					{
						correctAttributesEndingJohn3.Remove(index);
						indexCorrect24 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingJohn3.Count);
				for(int i=0; i<correctAttributesEndingJohn3.Count; i++)
				{
					GD.Print(correctAttributesEndingJohn3[i]);
				}
			}
		}


		private void _on_DropDownAttribute25_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingClaire1.Contains(index) && indexCorrect25 == false)
				{
					correctAttributesEndingClaire1.Remove(index);
					indexCopy25 = index;
					indexCorrect25 = true;

				}
				else if (indexCorrect25 && correctAttributesEndingClaire1.Count <4)
				{
					correctAttributesEndingClaire1.Add(indexCopy25);
					indexCorrect25 = false;
					indexCopy25 = index;

					if (correctAttributesEndingClaire1.Contains(index))
					{
						correctAttributesEndingClaire1.Remove(index);
						indexCorrect25 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire1.Count);
				for(int i=0; i<correctAttributesEndingClaire1.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingClaire2.Contains(index) && indexCorrect25 == false)
				{
					correctAttributesEndingClaire2.Remove(index);
					indexCopy25 = index;
					indexCorrect25 = true;

				}
				else if (indexCorrect25 && correctAttributesEndingClaire2.Count <4)
				{
					correctAttributesEndingClaire2.Add(indexCopy25);
					indexCorrect25 = false;
					indexCopy25 = index;

					if (correctAttributesEndingClaire2.Contains(index))
					{
						correctAttributesEndingClaire2.Remove(index);
						indexCorrect25 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire2.Count);
				for(int i=0; i<correctAttributesEndingClaire2.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingClaire3.Contains(index) && indexCorrect25 == false)
				{
					correctAttributesEndingClaire3.Remove(index);
					indexCopy25 = index;
					indexCorrect25 = true;

				}
				else if (indexCorrect25 && correctAttributesEndingClaire3.Count <4)
				{
					correctAttributesEndingClaire3.Add(indexCopy25);
					indexCorrect25 = false;
					indexCopy25 = index;

					if (correctAttributesEndingClaire3.Contains(index))
					{
						correctAttributesEndingClaire3.Remove(index);
						indexCorrect25 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire3.Count);
				for(int i=0; i<correctAttributesEndingClaire3.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire3[i]);
				}
			}
		}


		private void _on_DropDownAttribute26_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingClaire1.Contains(index) && indexCorrect26 == false)
				{
					correctAttributesEndingClaire1.Remove(index);
					indexCopy26 = index;
					indexCorrect26 = true;

				}
				else if (indexCorrect26 && correctAttributesEndingClaire1.Count <4)
				{
					correctAttributesEndingClaire1.Add(indexCopy26);
					indexCorrect26 = false;
					indexCopy26 = index;

					if (correctAttributesEndingClaire1.Contains(index))
					{
						correctAttributesEndingClaire1.Remove(index);
						indexCorrect26 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire1.Count);
				for(int i=0; i<correctAttributesEndingClaire1.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingClaire2.Contains(index) && indexCorrect26 == false)
				{
					correctAttributesEndingClaire2.Remove(index);
					indexCopy26 = index;
					indexCorrect26 = true;

				}
				else if (indexCorrect26 && correctAttributesEndingClaire2.Count <4)
				{
					correctAttributesEndingClaire2.Add(indexCopy26);
					indexCorrect26 = false;
					indexCopy26 = index;

					if (correctAttributesEndingClaire2.Contains(index))
					{
						correctAttributesEndingClaire2.Remove(index);
						indexCorrect26 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire2.Count);
				for(int i=0; i<correctAttributesEndingClaire2.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingClaire3.Contains(index) && indexCorrect26 == false)
				{
					correctAttributesEndingClaire3.Remove(index);
					indexCopy26 = index;
					indexCorrect26 = true;

				}
				else if (indexCorrect26 && correctAttributesEndingClaire3.Count <4)
				{
					correctAttributesEndingClaire3.Add(indexCopy26);
					indexCorrect26 = false;
					indexCopy26 = index;

					if (correctAttributesEndingClaire3.Contains(index))
					{
						correctAttributesEndingClaire3.Remove(index);
						indexCorrect26 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire3.Count);
				for(int i=0; i<correctAttributesEndingClaire3.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire3[i]);
				}
			}
		}


		private void _on_DropDownAttribute27_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingClaire1.Contains(index) && indexCorrect27 == false)
				{
					correctAttributesEndingClaire1.Remove(index);
					indexCopy27 = index;
					indexCorrect27 = true;

				}
				else if (indexCorrect27 && correctAttributesEndingClaire1.Count <4)
				{
					correctAttributesEndingClaire1.Add(indexCopy27);
					indexCorrect27 = false;
					indexCopy27 = index;

					if (correctAttributesEndingClaire1.Contains(index))
					{
						correctAttributesEndingClaire1.Remove(index);
						indexCorrect27 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire1.Count);
				for(int i=0; i<correctAttributesEndingClaire1.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingClaire2.Contains(index) && indexCorrect27 == false)
				{
					correctAttributesEndingClaire2.Remove(index);
					indexCopy27 = index;
					indexCorrect27 = true;

				}
				else if (indexCorrect27 && correctAttributesEndingClaire2.Count <4)
				{
					correctAttributesEndingClaire2.Add(indexCopy27);
					indexCorrect27 = false;
					indexCopy27 = index;

					if (correctAttributesEndingClaire2.Contains(index))
					{
						correctAttributesEndingClaire2.Remove(index);
						indexCorrect27 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire2.Count);
				for(int i=0; i<correctAttributesEndingClaire2.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingClaire3.Contains(index) && indexCorrect27 == false)
				{
					correctAttributesEndingClaire3.Remove(index);
					indexCopy27 = index;
					indexCorrect27=true;

				}
				else if (indexCorrect27 && correctAttributesEndingClaire3.Count <4)
				{
					correctAttributesEndingClaire3.Add(indexCopy27);
					indexCorrect27 = false;
					indexCopy27 = index;

					if (correctAttributesEndingClaire3.Contains(index))
					{
						correctAttributesEndingClaire3.Remove(index);
						indexCorrect27 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire3.Count);
				for(int i=0; i<correctAttributesEndingClaire3.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire3[i]);
				}
			}
		}


		private void _on_DropDownAttribute28_item_selected(int index)
		{
			if (endingPerfect2)
			{
				
				if (correctAttributesEndingClaire1.Contains(index) && indexCorrect27 == false)
				{
					correctAttributesEndingClaire1.Remove(index);
					indexCopy27 = index;
					indexCorrect27 = true;

				}
				else if (indexCorrect27 && correctAttributesEndingClaire1.Count <4)
				{
					correctAttributesEndingClaire1.Add(indexCopy27);
					indexCorrect27 = false;
					indexCopy27 = index;

					if (correctAttributesEndingClaire1.Contains(index))
					{
						correctAttributesEndingClaire1.Remove(index);
						indexCorrect27 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire1.Count);
				for(int i=0; i<correctAttributesEndingClaire1.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire1[i]);
				}
				
			}
			
			else if(endingOk2)
			{
				
				if (correctAttributesEndingClaire2.Contains(index) && indexCorrect28 == false)
				{
					correctAttributesEndingClaire2.Remove(index);
					indexCopy28 = index;
					indexCorrect28 = true;

				}
				else if (indexCorrect28 && correctAttributesEndingClaire2.Count <4)
				{
					correctAttributesEndingClaire2.Add(indexCopy28);
					indexCorrect28 = false;
					indexCopy28 = index;

					if (correctAttributesEndingClaire2.Contains(index))
					{
						correctAttributesEndingClaire2.Remove(index);
						indexCorrect28 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire2.Count);
				for(int i=0; i<correctAttributesEndingClaire2.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire2[i]);
				}
			}
			else if (ending23)
			{
				
				if (correctAttributesEndingClaire3.Contains(index) && indexCorrect28 == false)
				{
					correctAttributesEndingClaire3.Remove(index);
					indexCopy28 = index;
					indexCorrect28=true;

				}
				else if (indexCorrect28 && correctAttributesEndingClaire3.Count <4)
				{
					correctAttributesEndingClaire3.Add(indexCopy28);
					indexCorrect28 = false;
					indexCopy28 = index;

					if (correctAttributesEndingClaire3.Contains(index))
					{
						correctAttributesEndingClaire3.Remove(index);
						indexCorrect28 = true;

					}
				}
				GD.Print("---------------------");
				GD.Print("Length: "+correctAttributesEndingClaire3.Count);
				for(int i=0; i<correctAttributesEndingClaire3.Count; i++)
				{
					GD.Print(correctAttributesEndingClaire3[i]);
				}
			}
		}
		

		




		//CountPoints
		public void CountPoints()
		{
			
			GD.Print("Tigress1: "+correctAttributesEndingTigress1.Count);
			GD.Print("Tigress2: "+correctAttributesEndingTigress2.Count);
			GD.Print("Tigress3: "+correctAttributesEndingTigress3.Count);
			
			GD.Print("Hound1: "+correctAttributesEndingHound1.Count);
			GD.Print("Hound2: "+correctAttributesEndingHound2.Count);
			GD.Print("Hound3: "+correctAttributesEndingHound3.Count);
			
			GD.Print("John1: "+correctAttributesEndingJohn1.Count);
			GD.Print("John2: "+correctAttributesEndingJohn2.Count);
			GD.Print("John3: "+correctAttributesEndingJohn3.Count);
			
			GD.Print("Claire1 "+correctAttributesEndingClaire1.Count);
			GD.Print("Claire2: "+correctAttributesEndingClaire2.Count);
			GD.Print("Claire3: "+correctAttributesEndingClaire3.Count);
			
			if (settingCorrect)
			{
				points += 4;
			}
			
			if (settingCorrect2)
			{
				points += 4;
			}
			
			//endingPerfect == true;

			if (correctAttributesEndingTigress1.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingTigress1.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingTigress1.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingTigress1.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingHound1.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingHound1.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingHound1.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingHound1.Count == 3)
			{
				points += 2;
			}
			
			//endingOk == true;
			
			if (correctAttributesEndingTigress2.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingTigress2.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingTigress2.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingTigress2.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingHound2.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingHound2.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingHound2.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingHound2.Count == 3)
			{
				points += 2;
			}
			
			//ending3 == true;
			
			if (correctAttributesEndingTigress3.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingTigress3.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingTigress3.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingTigress3.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingHound3.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingHound3.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingHound3.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingHound3.Count == 3)
			{
				points += 2;
			}
			
			//endingPerfect2 == true;
			
			if (correctAttributesEndingJohn1.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingJohn1.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingJohn1.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingJohn1.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingClaire1.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingClaire1.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingClaire1.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingClaire1.Count == 3)
			{
				points += 2;
			}
			
			//endingOk2 == true;
			
			if (correctAttributesEndingJohn2.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingJohn2.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingJohn2.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingJohn2.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingClaire2.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingClaire2.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingClaire2.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingClaire2.Count == 3)
			{
				points += 2;
			}
			
			//ending23 == true;
			
			if (correctAttributesEndingJohn3.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingJohn3.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingJohn3.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingJohn3.Count == 3)
			{
				points += 2;
			}
			
			if (correctAttributesEndingClaire3.Count == 0)
			{
				points += 8;
			}
			else if (correctAttributesEndingClaire3.Count == 1)
			{
				points += 6;
			}
			else if (correctAttributesEndingClaire3.Count == 2)
			{
				points += 4;
			}
			else if (correctAttributesEndingClaire3.Count == 3)
			{
				points += 2;
			}

			if (GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").CurrentTime <= 300)
			{
				GD.Print("Time: "+GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").CurrentTime);
				points += 6;
			}
			
			
			
			_sharedNode.narrativePoints = points;
			_sharedNode.narrativeTime = GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").CurrentTime;
			GD.Print("points: "+points);
			_sharedNode.CompletedTasks.Add(AbilitySpecialization.Narrative);
			_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		}
	}
}




