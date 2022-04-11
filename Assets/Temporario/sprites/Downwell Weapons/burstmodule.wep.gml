#define init
global.sprite = sprite_add_weapon("BurstModule.png", 4, 3);
global.shot = sprite_add("Bullet 2.png",2,6,9)
global.hit = sprite_add("Bullet Hit.png",3,2,2)
global.sound = sound_add("Burst Module Shot.ogg")
global.swap = sound_add("Module Swap.ogg")

#define weapon_name
	return "Burst Module";

#define weapon_type
	return 1;

#define weapon_area
	return 5;

#define weapon_cost
	return 3;

#define weapon_load 
	return 7;

#define weapon_swap
	return global.swap;
	
#define weapon_sprt
	return global.sprite;

#define weapon_text
	return "@wBurst af@ter Burst";

#define weapon_fire
repeat(3)
{if instance_exists(self)
	weapon_post(4,-4,4);
	{with(instance_create(x,y,Bullet1)){
	sound_play(global.sound);
	team = other.team;
	damage = 2.5;
	creator = other;
	sprite_index = global.shot;
	spr_dead = global.hit;
	direction = other.gunangle + random_range(-3,3) ;
	image_angle = direction;
	speed = 16;}}			
	wait 2;
	}