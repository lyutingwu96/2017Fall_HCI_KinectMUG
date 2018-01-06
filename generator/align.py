from sys import argv
timeFix = float(argv[2])
with open(argv[1],'r') as f:
	bpm = f.readline()
	zero = f.readline()
	notes =[[0,0,0,0,0,0,]]
	for line in f:
		temp = line.split(',')[:-1]
		temp[0] = float(temp[0])
		print temp
		temp[0] += timeFix
		notes.append( temp)
with open(argv[1][:-4]+'-FIX.txt','w') as out:
        out.write(bpm)
	for note in notes:
		for i in note:
			out.write(str(i)+',')
		if not note == notes[-1]:
			out.write('\n')
		
