#ifndef CONTROLER_H
#define CONTROLER_H

#define BUTTON_A 0
#define BUTTON_B 1
#define BUTTON_START 2
#define BUTTON_SELECT 3
#define BUTTON_UP 4
#define BUTTON_DOWN 5
#define BUTTON_LEFT 6
#define BUTTON_RIGHT 7

uint8_t ButtonsPressed[8];

void Controller_Init(void);
void Controller_Update(void);
void Controller_StateMachineUpdate(void);

#endif
