# -*- coding: utf-8 -*-
"""
Created on Sun Jan  3 13:42:15 2021

@author: qsilv
"""

import numpy as np
from PIL import Image
import colorsys

WIDTH = 1024
MAX_ITERATIONS = 100

def get_rgb(i):
    color = 255*np.array(colorsys.hsv_to_rgb(i/255.0,1.0,0.5))
    return tuple(color.astype(int))

def mandelbrot(x,y):
    z0 = np.complex(x,y)
    z = 0
    for i in range(1, MAX_ITERATIONS):
        if(abs(z)>2):
            return get_rgb(i)
        z = z*z + z0
    return (0,0,0)

img = Image.new('RGB', (WIDTH, int(WIDTH/2)))
pixels = img.load()

for x in range(img.size[0]):
    print("%.2f %%" % (x/WIDTH*100.0))
    for y in range(img.size[1]):
        pixels[x,y] = mandelbrot((x-(0.75*WIDTH))/(WIDTH/4),
                                  (y-(WIDTH/4))/(WIDTH/4))
        
img.show()
        