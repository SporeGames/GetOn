extends Node


onready var main_music = load("res://SharedAssets/music/Soundtracks/Hauptraum Theme [V2].mp3")
onready var prog_music = load("res://SharedAssets/music/Soundtracks/Programmieren Theme Slowed Version.wav")
onready var gameStud_music = load("res://SharedAssets/music/Soundtracks/Game Design Theme Slowed Version.wav")
onready var gameDes_music = load("res://SharedAssets/music/Soundtracks/Game Studies Theme.mp3")
onready var narr_music = load("res://SharedAssets/music/Soundtracks/Narrative Theme.mp3")
onready var manage_music = load("res://SharedAssets/music/Soundtracks/Management Theme.mp3")
onready var soundG_music = load("res://SharedAssets/music/Soundtracks/Sound Design Theme.mp3")

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

func play_music6():

	$Music.stream = manage_music
	$Music.play()
	
func play_music7():

	$Music.stream = soundG_music
	$Music.play()
