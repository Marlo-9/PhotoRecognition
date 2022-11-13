from models.Whale import Whale
from models.Image import Image
import os
from dicttoxml import dicttoxml
from xml.dom.minidom import parseString
import pickle
import numpy as np

directory = 'images'

whales: Whale = []

for filename in os.listdir(directory):
    file = os.path.join(directory, filename)
    if(os.path.isdir(file)):
        newWhale = Whale(filename)
        print(newWhale.id + ' start adding!')
        for filename in os.listdir(file):
            file1 = os.path.join(file, filename)
            if(os.path.isdir(file1)):
                for filename in os.listdir(file1):
                    ext = os.path.splitext(filename)[-1].lower()
                    name = os.path.splitext(filename)[0]
                    if(ext == '.jpg'):
                        newImage = Image(os.path.abspath(os.path.join(file1, filename)), os.path.abspath(os.path.join(file1, name)) + '.png')
                        
                        #newWhale.addKeyPoints(newImage.getKeyPointAsArray())
                        newWhale.addDescriptors(newImage.des)

        whales.append(newWhale)
        print(newWhale.id + ' is added!')

for whale in whales:
   with open("saves/" + whale.id + ".whale", "wb") as fp:
       print(whale.id + ' start saving!')
       np.save(fp, np.array(whale.dess))
       print(whale.id + ' is saved!')

