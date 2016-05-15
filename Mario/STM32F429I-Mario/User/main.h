#ifndef MAIN_H
#define MAIN_H

#include "stm32f429i_discovery.h"
#include "stm32f429i_discovery_lcd.h"
#include "stm32f429i_discovery_ioe.h"
#include "stm32f429i_discovery_sdram.h"

#include "draw.h"
#include "game.h"
#include "controler.h"

void TimingDelay_Decrement(void);
void Delay(__IO uint32_t nTime);
void SDRAM_to_GRAM(void);



#endif
