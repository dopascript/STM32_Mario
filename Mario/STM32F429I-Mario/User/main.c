#include "main.h"
#include "level.h"
#include "controler.h"
#include <string.h>

static __IO uint32_t TimingDelay;

DMA2D_InitTypeDef DMA2D_InitStruct;

int main(void)
{
	uint16_t* frameBuffer;

  /* Setup SysTick Timer for 1 msec interrupts.*/
  if (SysTick_Config(SystemCoreClock / 1000))
  { 
    /* Capture error */ 
    while (1);
  }

  LCD_Init();

  LCD_LayerInit();
  
  /* LTDC reload configuration */  
  LTDC_ReloadConfig(LTDC_IMReload);
  
  /* Enable the LTDC */
  LTDC_Cmd(ENABLE);
  
  /* Set LCD foreground layer */
  LCD_SetLayer(LCD_FOREGROUND_LAYER);
  
  LCD_SetTransparency(0);

  /* Set LCD foreground layer */
  LCD_SetLayer(LCD_BACKGROUND_LAYER);

  SDRAM_Init();
  frameBuffer = (uint16_t*)SDRAM_BANK_ADDR;
  currentBuffer = frameBuffer + (screenWidth * screenHeight * 2);
  superBackGround = currentBuffer + (screenWidth * screenHeight * 2);

  /* LTDC configuration reload */  
  LTDC_ReloadConfig(LTDC_IMReload);

  Controller_Init();
  Game_Init();

  while(1)
  {
	  Game_Update();

	  memcpy(frameBuffer, currentBuffer, screenWidth * screenHeight * 2);
	  DMA2D_Init(&DMA2D_InitStruct);
	  DMA2D_StartTransfer();
  }
}

void SDRAM_to_GRAM(void)
{
	  /* Transfer data from SDRAM to GRAM using DMA2D */
	  /* Memory to Memory Transfer*/
	  DMA2D_DeInit();
	  DMA2D_InitStruct.DMA2D_Mode = DMA2D_M2M;
	  DMA2D_InitStruct.DMA2D_CMode = DMA2D_RGB565;
	  DMA2D_InitStruct.DMA2D_OutputGreen = 0x0;
	  DMA2D_InitStruct.DMA2D_OutputBlue = 0x00;
	  DMA2D_InitStruct.DMA2D_OutputRed = 0x00;
	  DMA2D_InitStruct.DMA2D_OutputAlpha = 0x0;
	  DMA2D_InitStruct.DMA2D_OutputMemoryAdd = 0xD0000000;
	  DMA2D_InitStruct.DMA2D_OutputOffset = 0x0;
	  DMA2D_InitStruct.DMA2D_NumberOfLine = 320;
	  DMA2D_InitStruct.DMA2D_PixelPerLine = 240;
	  DMA2D_Init(&DMA2D_InitStruct);

	  /* Start Transfer */
	  DMA2D_StartTransfer();
}

void Delay(__IO uint32_t nTime)
{
  TimingDelay = nTime;
  
  while(TimingDelay != 0);
}

void TimingDelay_Decrement(void)
{
  if (TimingDelay != 0x00)
  { 
    TimingDelay--;
  }
}
