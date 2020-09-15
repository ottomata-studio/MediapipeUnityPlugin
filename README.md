# Mediapipe Unity Plugin
This is a sample Unity (2019.4.10f1) Plugin to use Mediapipe (only tested on Linux).

## Prerequisites
### MediaPipe
Please be sure to install required packages and check if you can run the official demos on your machine.

### OpenCV
By default, it is assumed that you use OpenCV 3 and it is installed under `/usr/lib/x86_64-linux-gnu/`.
If your version or path is different, please edit `C/third_party/opencv_linux.BUILD` and `C/WORKSPACE`. 

### Protocol Buffer
The protocol buffer compiler is required.
It is also necessary to install .NET Core SDK(3.x) and .NET Core runtime 2.1 to build `Google.Protobuf.dll`. Here is a [link](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#1804-) on how to install, but you can read the commands here
```sh
#Install the packages
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

```sh
#Install the sdk
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1
```

```sh
#Install the runtime MAKE SURE TO SELECT 2.1
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-2.1
```

### Build
```sh
git clone https://github.com/homuler/MediapipeUnityPlugin.git
cd MediapipeUnityPlugin

### build libraries
# for GPU
make
# for CPU
# make MODE=cpu

make install
```

You may want to edit BUILD file before building so as to only include necessary calculators to reduce the library size.
For more information, please see the README of each scenes and the [BUILD file](https://github.com/homuler/MediapipeUnityPlugin/blob/master/C/mediapipe_api/BUILD).

### Models
The models used in example scenes are copied under `Assets/Mediapipe/SDK/Models` by running `make install`.

If you'd like to use other models, you should place them so that Unity can read.
For example, if your graph depends on `face_detection_front.tflite`, then you can place the model file under `Assets/Mediapipe/SDK/Models/` and set the path to the `model_path` value in your config file.

If neccessary, you can also change the model paths for subgraphs (e.g. FaceDetectionFrontCpu) by updating [mediapipe_model_path.diff](https://github.com/homuler/MediapipeUnityPlugin/blob/master/C/third_party/mediapipe_model_path.diff).

### Creating a unity project
You can basically just copy paste the whole directory, then add it to the unity hub. After that, navigate to the scenes folder `Assets/Mediapipe/Examples` and choose from the selection of scenes demo.

## Example Scenes
- Hello World!
- Face Detection (on CPU/GPU)
- Face Mesh (on CPU/GPU)
- Iris Tracking (on CPU/GPU)
- Hand Tracking (on CPU/GPU)
- Pose Tracking (on CPU/GPU)
- Hair Segmentation (on GPU)
- Object Detection (on CPU/GPU)

### Important files
To get started you can have a look at the base facemesh file tracker in `Assets/Mediapipe/Examples/FaceMesh/Scripts/FaceMeshGraph.cs` and start from there.

### Troubleshooting
If you encounter an error like below and you use OpenGL Core as the Unity's graphics APIs, please try Vulkan.

```txt
InternalException: INTERNAL: ; eglMakeCurrent() returned error 0x3000_mediapipe/mediapipe/gpu/gl_context_egl.cc:261)
```

### TODO
- [ ] Box Tracking (on CPU/GPU)
- [ ] Render annotations on Unity
- [ ] Android
- [ ] iOS
- [ ] Windows

## LICENSE
MIT
