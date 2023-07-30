import pylsl
import numpy as np
import datetime
from pylsl import StreamInlet, resolve_stream

HRList = []
HRMsequence = []
total_mean_HR = []
it = 0

# Define the MAC-address of the acquisition device used in OpenSignals
os_stream = resolve_stream("name", "OpenSignals")
# Create an inlet to receive signal samples from the stream
inlet = StreamInlet(os_stream[0])

start_time = datetime.datetime.now()
elapsed_time = datetime.datetime.now() - start_time

while elapsed_time.total_seconds() <= 150:

    elapsed_time = datetime.datetime.now() - start_time
    
    if it < 100:
        # Receive samples
        sample, timestamp = inlet.pull_sample()
        HRList.append(sample[2])
        print("Heart Rate = ", int(sample[2]))
        it +=1
    
    if it >= 99:
        it = 0
        HRMean = np.round(np.mean(HRList), 2)
        print("      Mean of 1 second Heart Rate = ", HRMean)
        HRMsequence.append(HRMean)
        HRList = []

    if len(HRMsequence) == 10:
        tenSecondsHR = np.round(np.mean(HRMsequence), 2)
        print("Mean of 10 seconds HR = ", tenSecondsHR)
        HRMsequence =[]
        total_mean_HR.append(tenSecondsHR)
    

HR_Baseline = np.round(np.mean(total_mean_HR), 2)
print("Heart Rate Baseline = ", HR_Baseline)