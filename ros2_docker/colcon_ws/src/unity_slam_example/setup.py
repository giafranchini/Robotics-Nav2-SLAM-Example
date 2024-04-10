import glob
import os

from setuptools import setup

package_name = 'unity_slam_example'

setup(
    name=package_name,
    version='0.0.1',
    packages=[],
    data_files=[
        ('share/ament_index/resource_index/packages', ['resource/' + package_name]),
        ('share/' + package_name, ['package.xml']),
        (os.path.join('share', package_name), [
                                                'behaviour_tree/follow_point.xml',
                                                'launch/unity_slam_example.launch.py',
                                                'launch/unity_viz_example.launch.py',
                                                'params/nav2_unity_jackal.yaml',
                                                'params/nav2_unity_tb.yaml',
                                                'params/slam_unity_jackal.yaml',
                                                'rviz/nav2_unity.rviz',
                                                ])
    ],
    install_requires=['setuptools'],
    zip_safe=True,
    maintainer='Unity Robotics',
    maintainer_email='unity-robotics@unity3d.com',
    description='Unity Robotics Nav2 SLAM Example',
    license='Apache 2.0',
    tests_require=['pytest']
)
