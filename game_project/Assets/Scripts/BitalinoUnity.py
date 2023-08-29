import socket
import time
import pylsl
import numpy as np
from pylsl import StreamInlet, resolve_stream
import datetime
from biosppy.signals import ecg
import pandas as pd


# Make Connection with Bitalino

### Define the MAC-address of the acquisition device used in OpenSignals
os_stream = resolve_stream("name", "OpenSignals")
# Create an inlet to receive signal samples from the stream
inlet = StreamInlet(os_stream[0])


# Make Connection with Unity3D
host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))


baseline = 77.68
# Set a window size for computing the Heart Rate
window_size = 10 #Seconds
ECG_list = []
fastValue = 0
stop_cond = False
start_window = datetime.datetime.now()
start_game = datetime.datetime.now()

result = []
# Path to save the results
result_path = 'C:/Users/vahid/Desktop/result.csv'
it = 1

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
        
        fastValueOld = fastValue
        
        if HR_mean < baseline and fastValue == 0:
            fastValue = 1
            print("go faster")

        if HR_mean > baseline:
            fastValue = 0
            print("go slower")

        if fastValueOld != fastValue:
            time_save = datetime.datetime.now() - start_game
            result.append({'id': it, 'time': int(time_save.total_seconds()), 'HR mean': HR_mean, 'fast value': fastValue})
            result_df = pd.DataFrame(result)
            result_df.to_csv(result_path, index=False)
            it += 1

        ECG_list = []
        start_window = datetime.datetime.now()
    
    posString = (str(fastValue)) 
    print(posString)

    #Converting string to Byte, and sending it to C#
    sock.sendall(posString.encode("UTF-8"))

    #receiveing data in Byte fron C#, and converting it to String
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)