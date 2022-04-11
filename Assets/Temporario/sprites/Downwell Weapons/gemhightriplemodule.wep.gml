#define init
global.sprite = sprite_add_weapon("GemHighTripleModule.png", -1, 4);
global.shot = sprite_add("Bullet 2 (Gem High).png",2,10,10)
global.hit = sprite_add("Bullet Hit.png",3,2,2)
global.sound = sound_add("Triple Module Shot (Gem High).ogg")
global.swap = sound_add("Module Swap.ogg")

#define weapon_name
	return "Gem High Triple Module";

#define weapon_type
	return 1;

#define weapon_area
	return 9;

#define weapon_cost
	return 2;

#define weapon_auto
	return true;

#define weapon_load 
	return 4.5;

#define weapon_swap
	return global.swap;
	
#define weapon_sprt
	return global.sprite;

#define weapon_text
	return "@rGematized @wtrio";

#define weapon_fire
weapon_post(6,-8,8);
for(i = -11; i < 11; i += 10)
{with(instance_create(x,y,Bullet1)){
	sound_play(global.sound);
	team = other.team;
	creator = other;
	damage = 5;
	sprite_index = global.shot;
	spr_dead = global.hit;
	direction = other.gunangle + (other.i * other.accuracy);
	image_angle = direction;
	speed = 19;}}
