# Mediapipe Unity Plugin
This is a sample Unity (2019.4.10f1) Plugin to use Mediapipe (only tested on Linux).

## Prerequisites

### Installing Bazel 3.4.0 for MediaPipe
Please be sure to install bazel 3.4.0 as newer versions seem to be broken:

<i>Installation From the [bazel documentation](https://docs.bazel.build/versions/master/install-ubuntu.html)</i>

```sh
#Add Bazel distribution URI as a package source
sudo apt install curl gnupg
curl -fsSL https://bazel.build/bazel-release.pub.gpg | gpg --dearmor > bazel.gpg
sudo mv bazel.gpg /etc/apt/trusted.gpg.d/
echo "deb [arch=amd64] https://storage.googleapis.com/bazel-apt stable jdk1.8" | sudo tee /etc/apt/sources.list.d/bazel.list
```

```sh
#Installing Bazel 3.4.0
sudo apt update && sudo apt install bazel-3.4.0 
sudo apt update && sudo apt full-upgrade
bazel-3.4.0
```

```sh
#Creating a symlink:
sudo ln -s /usr/bin/bazel-3.4.0 /usr/bin/bazel
bazel --version  # 3.4.0
```


### MediaPipe
Please be sure to install required packages and check if you can run the official demos on your machine.



### OpenCV
By default, it is assumed that you use OpenCV 3 and it is installed under `/usr/lib/x86_64-linux-gnu/`.
If your version or path is different, please edit `C/third_party/opencv_linux.BUILD` and `C/WORKSPACE`. 


### Protocol Buffer
It is neccesarray to install `Protocol Buffer` 3.13, 
```sh
#Download Prerequesites
sudo apt-get install autoconf automake libtool curl make g++ unzip
```
```sh
#Download Protocol Buffer
wget https://github.com/protocolbuffers/protobuf/releases/download/v3.13.0/protobuf-all-3.13.0.tar.gz
```
```sh
#Download extract and go in directory
tar -zxvf protobuf-all-3.13.0.tar.gz && cd protobuf-3.13.0
```
```sh
#Configurating the installation folder
./configure
```
```sh
#Installing with make
make

make check

make install 
```
```sh
#Refreshing shared library cache.
sudo ldconfig
```

### .NET Core + Runtime
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

### Downloading the right version of unity (2019.4.10f1)
As of right now, unity hub does not support downloading archived versions from the web browser. In order to download unity 2019.4.10f1, you need to user the <i>headless installer of UnityHub.AppImage</i>

```sh
#The UnityHub.AppImage folder
./UnityHub.AppImage --headless install --version 2019.4.10f1 --changeset 5311b3af6f69
```


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
