#include <stm32f4xx_gpio.h>
#include "controler.h"

#define STATE_BEGIN 0
#define STATE_LATCHING 1
#define STATE_SEND_CLOCK 2
#define STATE_READ_DATA 3

#define CLOCK_PIN GPIO_Pin_0
#define LATCH_PIN GPIO_Pin_1
#define DATA_PIN GPIO_Pin_2

uint8_t controllerStateButtonReading;
uint8_t controllerState;

void Controller_Init(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;

	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);

	GPIO_InitStructure.GPIO_Pin = DATA_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_Init(GPIOB,&GPIO_InitStructure);

	GPIO_InitStructure.GPIO_Pin = LATCH_PIN | CLOCK_PIN;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_Init(GPIOB,&GPIO_InitStructure);

	controllerState = STATE_BEGIN;
}

/*
void Controller_Update(void)
{
	uint8_t count;

	GPIO_SetBits(GPIOB, LATCH_PIN);
	Delay(1);
	GPIO_ResetBits(GPIOB, LATCH_PIN);

	for(count = 0;count < 8;count++)
	{
		ButtonsPressed[count] = GPIO_ReadInputDataBit(GPIOB, DATA_PIN);
		Delay (1);
		GPIO_SetBits(GPIOB, CLOCK_PIN);
		Delay (1);
		GPIO_ResetBits(GPIOB, CLOCK_PIN);
	}
}
*/

void Controller_StateMachineUpdate(void)
{
	switch(controllerState)
	{
		case STATE_BEGIN:
			{
				controllerStateButtonReading = 0;
				GPIO_SetBits(GPIOB, LATCH_PIN);
				controllerState = STATE_LATCHING;
			}
			break;
		case STATE_LATCHING:
			{
				GPIO_ResetBits(GPIOB, LATCH_PIN);
				ButtonsPressed[0] = GPIO_ReadInputDataBit(GPIOB, DATA_PIN);
				controllerStateButtonReading++;
				controllerState = STATE_READ_DATA;
			}
			break;
		case STATE_READ_DATA:
			{
				GPIO_SetBits(GPIOB, CLOCK_PIN);
				controllerState = STATE_SEND_CLOCK;
			}
			break;
		case STATE_SEND_CLOCK:
			{

				GPIO_ResetBits(GPIOB, CLOCK_PIN);
				ButtonsPressed[controllerStateButtonReading] = GPIO_ReadInputDataBit(GPIOB, DATA_PIN);
				controllerStateButtonReading++;
				if(controllerStateButtonReading < 8)
				{
					controllerState = STATE_READ_DATA;
				}
				else
				{
					controllerState = STATE_BEGIN;
				}
			}
			break;
	}
}
