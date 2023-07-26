import socket
import time
import pylsl
import numpy as np
from pylsl import StreamInlet, resolve_stream

# Make Connection with Bitalino

### Define the MAC-address of the acquisition device used in OpenSignals
os_stream = resolve_stream("name", "OpenSignals")
# Create an inlet to receive signal samples from the stream
inlet = StreamInlet(os_stream[0])


# Make Connection with Unity3D
host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))

fastValue = 0
baseline = 125.5
HRList = []
HRMsequence = []
it = 0
a = 1
#time.sleep(4) #sleep 0.5 sec

while a < 100:
    if it < 100:
        # Receive samples
        sample, timestamp = inlet.pull_sample()
        HRList.append(sample[2])
        #print("Heart Rate = ", int(sample[2]))
        it +=1
        
    if it >= 99:
        it = 0
        HRMean = np.round(np.mean(HRList), 2)
        print("      The Mean of Heart Rate = ", HRMean)
        HRMsequence.append(HRMean)
        HRList = []

    if len(HRMsequence) == 10:
        tenSecondsHR = np.round(np.mean(HRMsequence), 2)
        if tenSecondsHR > baseline and fastValue == 0:
            fastValue = 1
            # slow = 0
            print("go faster")
        if tenSecondsHR < baseline:
            #slow = 1
            fastValue = 0
            print("go slower")
        HRMsequence = []
    
    posString = (str(fastValue)) 
    print(posString)

    #Converting string to Byte, and sending it to C#
    sock.sendall(posString.encode("UTF-8"))

    #receiveing data in Byte fron C#, and converting it to String
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)