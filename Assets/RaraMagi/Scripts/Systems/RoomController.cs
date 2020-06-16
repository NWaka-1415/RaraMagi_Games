using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RaraMagi.Systems
{
    public class RoomController : MonoBehaviour
    {
        public enum Room
        {
            Title,
            Game,
            Settings,
        }

        private Dictionary<Room, string> rooms;

        public Room CurrentRoom { get; private set; }
        public Room PreviousRoom { get; private set; }

        public void Initialize(Room room = Room.Title)
        {
            CurrentRoom = room;

            SetUp(room);
        }

        public void GoToRoom(Room room)
        {
            PreviousRoom = CurrentRoom;
            CurrentRoom = room;

            AsyncOperation operation = SceneManager.LoadSceneAsync(rooms[room], LoadSceneMode.Additive);
            operation.allowSceneActivation = false;

            StartCoroutine(Loading(operation));
        }

        IEnumerator Loading(AsyncOperation operation)
        {
            operation.allowSceneActivation = true;
            while (!operation.isDone)
            {
                yield return null;
            }

            yield return null;
            if (CurrentRoom != PreviousRoom) SceneManager.UnloadSceneAsync(rooms[PreviousRoom]);
        }

        private void SetUp(Room room)
        {
            rooms = new Dictionary<Room, string>()
            {
                {Room.Title, "TitleScene"},
                {Room.Game, "GameScene"},
                {Room.Settings, "SettingsScene"},
            };


            GoToRoom(room);
        }
    }
}