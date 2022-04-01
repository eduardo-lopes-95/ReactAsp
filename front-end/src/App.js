import React, {useState} from "react";

function App() {

  const [post, setPosts] = useState([]);

  function getPosts() {
    const url = 'https://localhost:7162/get-all-posts';

    fetch(url, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(postsFromServer => {
      console.log(postsFromServer);
      setPosts(postsFromServer)
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>ASP.NET Core React Tutorial</h1>
          </div>
          <div className="mt-5">
            <button onClick={getPosts} className="btn btn-dark btn-large w-100">Get posts from server</button>
            <button onClick={() => {}} className="btn btn-secondary btn-large w-100 mt-4">Create new post</button>
          </div>
          {
            renderPostTable()
          }
        </div>
      </div>
    </div>
  );

  function renderPostTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">PostId (PK)</th>
              <th scope="col">Title</th>
              <th scope="col">Content</th>
              <th scope="col">Crud Operations</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>Post 1 title</td>
              <td>Post 1 content</td>
              <td>
                <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                <button className="btn btn-secondary btn-lg">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    )
  }

}

export default App;
