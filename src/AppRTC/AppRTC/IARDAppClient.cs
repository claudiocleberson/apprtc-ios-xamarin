﻿using Foundation;
using WebRTCBinding;

namespace AppRTC
{

	public enum ARDAppClientState : long
	{
		Disconnected,
		Connecting,
		Connected,
        ConnectionFailed
	}

	public interface IARDAppClient
	{
		IARDAppClientDelegate Delegate { get; }

		void SetServerHostUrl(string serverHostUrl);
		void ConnectToRoomWithId(string roomName);
		void Disconnect();
		void SwapCameraToBack();
		void SwapCameraToFront();

		void MuteAudioIn();
		void UnmuteAudioIn();      

        void MuteVideoIn();
        void UnmuteVideoIn();
	}

	public interface IARDAppClientDelegate
	{
		void ReceivedMedia(bool haveVideo, bool haveAudio);
		bool ShouldConnect(ARDRegisterResponse registerResponse);
		void DidChangeState(IARDAppClient client, ARDAppClientState state);
		void DidReceiveLocalVideoTrack(IARDAppClient client, RTCVideoTrack localVideoTrack);
		void DidReceiveRemoteVideoTrack(IARDAppClient client, RTCVideoTrack remoteVideoTrack);
		void DidError(IARDAppClient client, NSError error);
	}
}
