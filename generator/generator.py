#!/usr/bin/env python
import pygame
from Tkinter import *
from  librosa import load
from  librosa.onset import onset_strength
from librosa.beat import tempo
import time
from sys import argv
file = argv[1]
minTime = 0.024
class Application(Frame):
    #BPM,starttime,notes
    def __init__(self,parent):
        Frame.__init__(self, parent)
        self.parent=parent
        pygame.init()
        pygame.mixer.init()
        pygame.mixer.music.load(file)
        self.BPM=0
        self.notes = [[0,0,0,0,0,0]]
        self.starttime = 0
        self.parent.bind('<Key>',self.press)
        self.GUI()
    def bpm(self):
        y, sr = load(file)
        onset_env = onset_strength(y, sr=sr)
        self.BPM= tempo(onset_envelope=onset_env, sr=sr)[0]
        print 'bpm : ' ,self.BPM
    def play(self):
        self.notes = [[0,0,0,0,0,0]]
        pygame.mixer.music.play()
        self.starttime= time.time()
        print self.starttime
    def getTime(self):
        return time.time()-self.starttime
    def press(self,event):
        time  = float(pygame.mixer.music.get_pos())/1000.0	
        #time = self.getTime()
        char = repr(event.char)

        if time - self.notes[-1][0] >= minTime:
        	self.notes.append([time,0,0,0,0,0])
        if char[1] == 'q':
            self.notes[-1][1] = 1 
            print self.notes[-1][0], self.notes[-1][1:]
        if char[1] == 'w':
            self.notes[-1][2] = 1
            print self.notes[-1][0], self.notes[-1][1:]
        if char[1] == 'e':
            self.notes[-1][3] = 1
            print self.notes[-1][0], self.notes[-1][1:]
        if char[1] == 'o':
            self.notes[-1][4] = 1
            print self.notes[-1][0], self.notes[-1][1:]
        if char[1] == 'p':
            self.notes[-1][5] = 1
            print self.notes[-1][0], self.notes[-1][1:]
    def save(self):
    	print "write self.BPM",self.BPM
        with open(file[:-3]+'txt','w') as f:
            f.write(str(self.BPM)+'\n')
            for i in self.notes:
                for j in i:
                    f.write(str(j)+',')
                if not i == self.notes[-1]:
                	f.write('\n')
        print "saved to file..."

    def GUI(self):
        self.pack(fill=BOTH, expand=1)  
        Button(self,text="BPM", command=self.bpm).grid(column=0,row=1) 
        Button(self,text='Play', command=self.play).grid(column=1,row=1)
     #   Button(self,text="test",command=self.getTime).grid(column=2,row=1)
        Button(self,text="save",command=self.save).grid(column=3,row=1)
        Label(self,text="Usage : Play -> BPM -> save").grid(column=0,columnspan=5,row=2)
        Label(self,text="KEY: Q W E O P").grid(column=0,columnspan=5,row=3)


root = Tk()
app = Application(root)
root.geometry("601x150")
root.mainloop()
