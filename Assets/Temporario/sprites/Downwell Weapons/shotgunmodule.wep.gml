#define init
global.sprite = sprite_add_weapon("ShotgunModule.png", 3, 2);
global.shot = sprite_add("Shell.png",2,6,8)
global.hit = sprite_add("Bullet Hit.png",3,2,2)
global.sound = sound_add("Shotgun Module Shot.ogg")
global.swap = sound_add("Module Swap.ogg")

#define weapon_name
	return "Shotgun Module";

#define weapon_type
	return 2;

#define weapon_area
	return 5;

#define weapon_cost
	return 1;

#define weapon_load 
	return weapon_get_load(wep_shotgun);

#define weapon_swap
	return global.swap;
	
#define weapon_sprt
	return global.sprite;

#define weapon_text
	return "@wExtra @rpower";

#define weapon_fire 
weapon_post(6, -6, 8);
repeat(8)
{
  with instance_create(x,y,Bullet2)
  {
	motion_add(other.gunangle + (random_range(-14,14) * other.accuracy),random_range(12,18));
	sound_play(global.sound);
	sprite_index = global.shot;
	damage = 2.5;
	team = other.team;
	image_angle = direction;
	creator = other;
  }
}