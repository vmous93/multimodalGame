import socket
import time
import pylsl
import numpy as np
from pylsl import StreamInlet, resolve_stream
import datetime
from biosppy.signals import ecg

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
baseline = 78.5
# Set a window size for computing the Heart Rate
window_size = 10 #Seconds
ECG_list = []
stop_cond = False
#time.sleep(4) #sleep 0.5 sec
start_window = datetime.datetime.now()

while stop_cond == False:

    stop_window = datetime.datetime.now() - start_window

    # Receive samples
    sample, timestamp = inlet.pull_sample()
    ECG_list.append(sample[2])

    if int(stop_window.total_seconds()) > 0 and int(stop_window.total_seconds()) % window_size == 0:
        
        # ECG signal processing using biosppy library and extract Heart Rate
        HR = ecg.ecg(signal=ECG_list, sampling_rate=1000., show=False)["heart_rate"]

        # Compute HR mean for each window
        HR_mean = np.round(np.mean(HR), 2)
        print("Mean of", window_size, "seconds HR = ", HR_mean)

        if HR_mean < baseline and fastValue == 0:
            fastValue = 1
            print("go faster")

        if HR_mean > baseline:
            fastValue = 0
            print("go slower")

        ECG_list = []
        start_window = datetime.datetime.now()
    
    posString = (str(fastValue)) 
    print(posString)

    #Converting string to Byte, and sending it to C#
    sock.sendall(posString.encode("UTF-8"))

    #receiveing data in Byte fron C#, and converting it to String
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)