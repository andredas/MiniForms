using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;

namespace MiniForms.UnitTest
{
    [TestFixture()]
    class SwapTest
    {
        /// <summary>
        /// Swaps around elements in the list
        /// </summary>
        /// <param name="currentList">The list where you want to get the element from.</param>
        /// <param name="targetList">The list where you want to send the element to.</param>
        /// <param name="obj">The object you want to use</param>
        [Test]
        public void SwapItem(ListBox currentList, ListBox targetList, object obj)
        {
            currentList.Items.Remove(obj);
            targetList.Items.Add(obj);
        }

        [Test]
        public void SwapAllItems(ListBox currentList, ListBox targetList)
        {
            foreach (var item in currentList.Items)
            {
                SwapItem(currentList, targetList, item);
            }
        }
    }

    

}
