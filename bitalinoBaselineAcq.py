import pylsl
import numpy as np
import datetime
from pylsl import StreamInlet, resolve_stream
from biosppy import storage
from biosppy.signals import ecg

# Set a window size for computing the Heart Rate
window_size = 10 #Seconds
ECG_list = []
total_mean_HR = []

# Define the MAC-address of the acquisition device used in OpenSignals
os_stream = resolve_stream("name", "OpenSignals")
# Create an inlet to receive signal samples from the stream
inlet = StreamInlet(os_stream[0])


start_time = datetime.datetime.now()
elapsed_time = datetime.datetime.now() - start_time
start_window = datetime.datetime.now()

while elapsed_time.total_seconds() <= 150:

    elapsed_time = datetime.datetime.now() - start_time
    stop_window = datetime.datetime.now() - start_window
    
    # Receive samples
    sample, timestamp = inlet.pull_sample()
    ECG_list.append(sample[2])
    #print("ECG = ", sample[2])

    if int(stop_window.total_seconds()) > 0 and int(stop_window.total_seconds()) % window_size == 0:
        
        # ECG signal processing using biosppy library and extract Heart Rate
        HR = ecg.ecg(signal=ECG_list, sampling_rate=1000., show=False)["heart_rate"]

        # Compute HR mean for each window
        HR_mean = np.round(np.mean(HR), 2)
        print("Mean of", window_size, "seconds HR = ", HR_mean)
        
        total_mean_HR.append(HR_mean)

        ECG_list = []
        start_window = datetime.datetime.now()
    

HR_Baseline = np.round(np.mean(total_mean_HR), 2)
print("Heart Rate Baseline = ", HR_Baseline)
