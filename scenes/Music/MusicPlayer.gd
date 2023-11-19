extends Node


onready var main_music = load("res://scenes/Music/Soundtracks/Hauptraum Theme [V2].wav")
onready var prog_music = load("res://scenes/Music/Soundtracks/Programmieren Theme.wav")
onready var gameDes_music = load("res://scenes/Music/Soundtracks/Game Design Theme.wav")
onready var gameStud_music = load("res://scenes/Music/Soundtracks/Game Studies Theme.wav")
onready var narr_music = load("res://scenes/Music/Soundtracks/Narrative Theme.wav")


func play_music():
	
	$Music.stream = main_music
	$Music.play()

func play_music2():

	$Music.stream = prog_music
	$Music.play()
	
func play_music3():

	$Music.stream = gameDes_music
	$Music.play()

func play_music4():

	$Music.stream = gameStud_music
	$Music.play()
	
func play_music5():

	$Music.stream = narr_music
	$Music.play()
