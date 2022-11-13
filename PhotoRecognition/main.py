from models import Whale
import os
import sys
import xml.etree.ElementTree as et
import cv2 as cv
from ast import literal_eval
import skimage.io
import matplotlib.pyplot as plt
import numpy as np
import csv
import shutil


if len(sys.argv) > 1:
    root = sys.argv[1]

directory = 'saves'

whales = []

sift = cv.SIFT_create()
flann = cv.BFMatcher()

for filename in os.listdir(directory):
    ext = os.path.splitext(filename)[-1].lower()
    name = os.path.splitext(filename)[0]
    print(name + ' file is parsing')
    if(ext == '.whale'):
        newWhale = Whale(name)
        newWhale.dess = np.load(os.path.join(directory, filename), allow_pickle=True)

        whales.append(newWhale)

for whaleDir in os.listdir(root):
    for whale in whales:
        whale.matchesCount = 0
    print(whaleDir)

    file = os.path.join(root, whaleDir)
    for datasDir in os.listdir(file):
        file1 = os.path.join(file, datasDir)
        i = 0
        print(datasDir)
        for image in os.listdir(file1):
            if (i >= 1):
                break
            
            ext = os.path.splitext(image)[-1].lower()
            name = os.path.splitext(image)[0]

            if (ext == '.jpg'):
                print(image)
                print(ext)
                
                img = skimage.io.imread(os.path.join(file1, image))
                mask = skimage.io.imread(os.path.join(file1, name) + '.png')
                kp1, des1 = sift.detectAndCompute(img, mask)

                for whale in whales:
                    print(whale.id)
                    ds = whale.dess
                    
                    for d in ds:
                        matches = flann.knnMatch(des1, d, k=2)

                        try:
                            for m, n in matches:
                                if m.distance < 0.7*n.distance:
                                    whale.matchesCount += 1
                        except:
                            pass
                            
                    #print('{} have {} matches'.format(whale.id, whale.matchesCount))
                i+=1
    #for whale in whales:
    #    print(whale.matchesCount)

    whales.sort(key=lambda x: x.matchesCount, reverse=True)

    with open('Result/RAD.csv', 'a', newline='') as fp:
        writer = csv.writer(fp, delimiter=';', quotechar='|', quoting=csv.QUOTE_MINIMAL)
        writer.writerow([whaleDir, whales[0].id, whales[1].id, whales[2].id, whales[3].id, whales[4].id])

    whaleResDir = os.path.join('Result', whales[0].id)
    if (not os.path.exists(whaleResDir)):
        os.mkdir(whaleResDir)
    
    for datasDir in os.listdir(file):
        file1 = os.path.join(file, datasDir)
        for image in os.listdir(file1):
            shutil.copy2(os.path.abspath(os.path.join(file1, image)), whaleResDir)

print('start matches')

