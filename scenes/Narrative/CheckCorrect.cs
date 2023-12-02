using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using iText.Layout.Element;

namespace GetOn.scenes.Narrative
{
	public class CheckCorrect : Area2D
	{
		private SharedNode _sharedNode;
		
		//Story 1 
		private bool endingPerfect;
		private bool endingOk;
		private bool settingCorrect;
		private int points;
		private Button _submit;

		private List<int> correctAttributesKriv = new List<int> { 1, 2, 3, 4 };
		private List<int> correctAttributesAshe = new List<int> { 2, 4, 5, 6 };
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

		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			endingPerfect = false;
			endingOk = false;
			settingCorrect = false;
			points = 0;
			_submit = GetNode<Button>("/root/Narrative/Submit");
			_submit.Connect("pressed", this, nameof(CountPoints));
		}

		//Check if correct ending entered 

		private void _on_CheckCorrect_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Ending1")
				{
					endingPerfect = true;
					GD.Print(endingPerfect);
				}
				else if (kinematicBody.Name == "Ending2")
				{

					endingOk = true;
					GD.Print("endingOk");

				}
				else if (kinematicBody.Name == "Ending21")
				{
					endingPerfect2 = true;
				}
				else if (kinematicBody.Name == "Ending22")
				{
					endingOk2 = true;
				}
				else if (kinematicBody.Name == "Ending31")
				{
					endingPerfect3 = true;
				}
				else if (kinematicBody.Name == "Ending32")
				{
					endingOk3 = true;
				}
			}
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
				else if (kinematicBody.Name == "Ending21")
				{
					endingPerfect2 = false;
				}
				else if (kinematicBody.Name == "Ending22")
				{
					endingOk2 = false;
				}
				else if (kinematicBody.Name == "Ending31")
				{
					endingPerfect3 = false;
				}
				else if (kinematicBody.Name == "Ending32")
				{
					endingOk3 = false;
				}
			}
		}

		//First Story

		private void _on_DropDownSetting_item_selected(int index)
		{
			if (index == 1)
			{
				settingCorrect = true;
				GD.Print("ye");
			}
			else
			{
				settingCorrect = false;
			}
		}

		private void _on_DropDownAttribute1_item_selected(int index)
		{
			if (correctAttributesKriv.Contains(index))
			{
				correctAttributesKriv.Remove(index);
				indexCopy1 = index;
				indexCorrect1 = true;
			}
			else if (indexCorrect1)
			{
				correctAttributesKriv.Add(indexCopy1);
			}
		}

		private void _on_DropDownAttribute2_item_selected(int index)
		{
			if (correctAttributesKriv.Contains(index))
			{
				correctAttributesKriv.Remove(index);
				indexCopy2 = index;
				indexCorrect2 = true;
			}
			else if (indexCorrect2)
			{
				correctAttributesKriv.Add(indexCopy2);
			}
		}


		private void _on_DropDownAttribute3_item_selected(int index)
		{
			if (correctAttributesKriv.Contains(index))
			{
				correctAttributesKriv.Remove(index);
				indexCopy3 = index;
				indexCorrect3 = true;
			}
			else if (indexCorrect3)
			{
				correctAttributesKriv.Add(indexCopy3);
			}
		}


		private void _on_DropDownAttribute4_item_selected(int index)
		{

			if (correctAttributesKriv.Contains(index))
			{
				correctAttributesKriv.Remove(index);
				indexCopy4 = index;
				indexCorrect4 = true;
			}
			else if (indexCorrect4)
			{
				correctAttributesKriv.Add(indexCopy4);
			}
		}

		private void _on_DropDownAttribute5_item_selected(int index)
		{
			if (correctAttributesAshe.Contains(index))
			{
				correctAttributesAshe.Remove(index);
				indexCopy5 = index;
				indexCorrect5 = true;
			}
			else if (indexCorrect5)
			{
				correctAttributesAshe.Add(indexCopy5);
			}
		}


		private void _on_DropDownAttribute6_item_selected(int index)
		{
			if (correctAttributesAshe.Contains(index))
			{
				correctAttributesAshe.Remove(index);
				indexCopy6 = index;
				indexCorrect6 = true;
			}
			else if (indexCorrect6)
			{
				correctAttributesAshe.Add(indexCopy6);
			}
		}


		private void _on_DropDownAttribute7_item_selected(int index)
		{
			if (correctAttributesAshe.Contains(index))
			{
				correctAttributesAshe.Remove(index);
				indexCopy7 = index;
				indexCorrect7 = true;
			}
			else if (indexCorrect7)
			{
				correctAttributesAshe.Add(indexCopy7);
			}
		}


		private void _on_DropDownAttribute8_item_selected(int index)
		{
			if (correctAttributesAshe.Contains(index))
			{
				correctAttributesAshe.Remove(index);
				indexCopy8 = index;
				indexCorrect8 = true;
			}
			else if (indexCorrect8)
			{
				correctAttributesAshe.Add(indexCopy8);
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
			if (correctAttributesJim.Contains(index))
			{
				correctAttributesJim.Remove(index);
				indexCopy21 = index;
				indexCorrect21 = true;
			}
			else if (indexCorrect21)
			{
				correctAttributesJim.Add(indexCopy21);
			}
		}


		private void _on_DropDownAttribute22_item_selected(int index)
		{
			if (correctAttributesJim.Contains(index))
			{
				correctAttributesJim.Remove(index);
				indexCopy22 = index;
				indexCorrect22 = true;
			}
			else if (indexCorrect22)
			{
				correctAttributesJim.Add(indexCopy22);
			}
		}


		private void _on_DropDownAttribute23_item_selected(int index)
		{
			if (correctAttributesJim.Contains(index))
			{
				correctAttributesJim.Remove(index);
				indexCopy23 = index;
				indexCorrect23 = true;
			}
			else if (indexCorrect23)
			{
				correctAttributesJim.Add(indexCopy23);
			}
		}


		private void _on_DropDownAttribute24_item_selected(int index)
		{
			if (correctAttributesJim.Contains(index))
			{
				correctAttributesJim.Remove(index);
				indexCopy24 = index;
				indexCorrect24 = true;
			}
			else if (indexCorrect24)
			{
				correctAttributesJim.Add(indexCopy24);
			}
		}


		private void _on_DropDownAttribute25_item_selected(int index)
		{
			if (correctAttributesEmilia.Contains(index))
			{
				correctAttributesEmilia.Remove(index);
				indexCopy25 = index;
				indexCorrect25 = true;
			}
			else if (indexCorrect25)
			{
				correctAttributesEmilia.Add(indexCopy25);
			}
		}


		private void _on_DropDownAttribute26_item_selected(int index)
		{
			if (correctAttributesEmilia.Contains(index))
			{
				correctAttributesEmilia.Remove(index);
				indexCopy26 = index;
				indexCorrect26 = true;
			}
			else if (indexCorrect26)
			{
				correctAttributesEmilia.Add(indexCopy26);
			}
		}


		private void _on_DropDownAttribute27_item_selected(int index)
		{
			if (correctAttributesEmilia.Contains(index))
			{
				correctAttributesEmilia.Remove(index);
				indexCopy27 = index;
				indexCorrect27 = true;
			}
			else if (indexCorrect27)
			{
				correctAttributesEmilia.Add(indexCopy27);
			}
		}


		private void _on_DropDownAttribute28_item_selected(int index)
		{
			if (correctAttributesEmilia.Contains(index))
			{
				correctAttributesEmilia.Remove(index);
				indexCopy28 = index;
				indexCorrect28 = true;
			}
			else if (indexCorrect28)
			{
				correctAttributesEmilia.Add(indexCopy28);
			}
		}

		//Third Story

		private void _on_DropDownSetting3_item_selected(int index)
		{
			if (index == 6)
			{
				settingCorrect3 = true;
				GD.Print(settingCorrect3);
			}
			else
			{
				settingCorrect3 = false;
			}
		}

		private void _on_DropDownAttribute31_item_selected(int index)
		{
			if (correctAttributesNora.Contains(index))
			{
				correctAttributesNora.Remove(index);
				indexCopy31 = index;
				indexCorrect31 = true;
			}
			else if (indexCorrect31)
			{
				correctAttributesNora.Add(indexCopy31);
			}
		}


		private void _on_DropDownAttribute32_item_selected(int index)
		{
			if (correctAttributesNora.Contains(index))
			{
				correctAttributesNora.Remove(index);
				indexCopy32 = index;
				indexCorrect32 = true;
			}
			else if (indexCorrect32)
			{
				correctAttributesNora.Add(indexCopy32);
			}
		}


		private void _on_DropDownAttribute33_item_selected(int index)
		{
			if (correctAttributesNora.Contains(index))
			{
				correctAttributesNora.Remove(index);
				indexCopy33 = index;
				indexCorrect33 = true;
			}
			else if (indexCorrect33)
			{
				correctAttributesNora.Add(indexCopy33);
			}
		}


		private void _on_DropDownAttribute34_item_selected(int index)
		{
			if (correctAttributesNora.Contains(index))
			{
				correctAttributesNora.Remove(index);
				indexCopy34 = index;
				indexCorrect34 = true;
			}
			else if (indexCorrect34)
			{
				correctAttributesNora.Add(indexCopy34);
			}
		}


		private void _on_DropDownAttribute35_item_selected(int index)
		{
			if (correctAttributesAnne.Contains(index))
			{
				correctAttributesAnne.Remove(index);
				indexCopy35 = index;
				indexCorrect35 = true;
			}
			else if (indexCorrect35)
			{
				correctAttributesAnne.Add(indexCopy35);
			}
		}


		private void _on_DropDownAttribute36_item_selected(int index)
		{
			if (correctAttributesAnne.Contains(index))
			{
				correctAttributesAnne.Remove(index);
				indexCopy36 = index;
				indexCorrect36 = true;
			}
			else if (indexCorrect36)
			{
				correctAttributesAnne.Add(indexCopy36);
			}
		}


		private void _on_DropDownAttribute37_item_selected(int index)
		{
			if (correctAttributesAnne.Contains(index))
			{
				correctAttributesAnne.Remove(index);
				indexCopy37 = index;
				indexCorrect37 = true;
			}
			else if (indexCorrect37)
			{
				correctAttributesAnne.Add(indexCopy37);
			}
		}


		private void _on_DropDownAttribute38_item_selected(int index)
		{
			if (correctAttributesAnne.Contains(index))
			{
				correctAttributesAnne.Remove(index);
				indexCopy38 = index;
				indexCorrect38 = true;
			}
			else if (indexCorrect38)
			{
				correctAttributesAnne.Add(indexCopy38);
			}
		}




		//CountPoints
		public void CountPoints()
		{
			if (endingPerfect && endingOk == false)
			{
				points += 6;
			}
			else if (endingOk && endingPerfect == false)
			{
				points += 3;
			}

			if (endingPerfect2 && endingOk2 == false)
			{
				points += 6;
			}
			else if (endingOk2 && endingPerfect2 == false)
			{
				points += 3;
			}

			if (endingPerfect3 && endingOk3 == false)
			{
				points += 6;
			}
			else if (endingOk3 && endingPerfect3 == false)
			{
				points += 3;
			}


			if (settingCorrect)
			{
				points += 2;
			}


			if (correctAttributesKriv.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesKriv.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesKriv.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesKriv.Count == 3)
			{
				points += 1;
			}

			if (correctAttributesAshe.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesAshe.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesAshe.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesAshe.Count == 3)
			{
				points += 1;
			}

			if (correctAttributesJim.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesJim.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesJim.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesJim.Count == 3)
			{
				points += 1;
			}

			if (correctAttributesEmilia.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesEmilia.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesEmilia.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesEmilia.Count == 3)
			{
				points += 1;
			}

			if (settingCorrect2)
			{
				points += 2;
			}

			if (correctAttributesNora.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesNora.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesNora.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesNora.Count == 3)
			{
				points += 1;
			}

			if (correctAttributesAnne.Count == 0)
			{
				points += 4;
			}
			else if (correctAttributesAnne.Count == 1)
			{
				points += 3;
			}
			else if (correctAttributesAnne.Count == 2)
			{
				points += 2;
			}
			else if (correctAttributesAnne.Count == 3)
			{
				points += 1;
			}

			if (settingCorrect3)
			{
				points += 2;
			}
			_sharedNode.narrativePoints = points;
			GD.Print(points);
			_sharedNode.CompletedTasks.Add("narrative");
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}
	}
}




