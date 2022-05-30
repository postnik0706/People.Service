namespace PeopleViewer.Presentation.Tests
{
    [TestClass]
    public class PeopleViewModelTests
    {
        [TestMethod]
        public void People_OnRefreshPeople_IsPopupated()
        {
            var viewModel = new PeopleViewModel(new FakeReader());
            
            viewModel.RefreshPeople();

            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [TestMethod]
        public void People_OnClear_IsEmpty()
        {
            var viewModel = new PeopleViewModel(new FakeReader());
            viewModel.RefreshPeople();
            Assert.AreNotEqual(0, viewModel.People.Count());

            viewModel.ClearPeople();

            Assert.AreEqual(0, viewModel.People.Count());
        }
    }
}