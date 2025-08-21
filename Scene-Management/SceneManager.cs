using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement
{
    internal class SceneManager
    {
        private readonly Stack<IScene> sceneStack;

        public SceneManager()
        {
            sceneStack = new();
        }

        public void AddScene(IScene scene)
        {
            scene.Load();

            sceneStack.Push(scene);
        }

        public void RemoveScene(IScene scene)
        {
            sceneStack.Pop();   
        }

        public IScene GetCurrentScene()
        {
            return sceneStack.Peek();
        }
    }
}
