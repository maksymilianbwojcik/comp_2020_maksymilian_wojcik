import React, { Component } from 'react';

export class Books extends Component {
    static displayName = Books.name;
    
    constructor(props) {
        super(props);
            this.state = { books:[], loading: true, name: '', author:'', publisher:'', year:2020};
        this.mySubmitHandler = this.mySubmitHandler.bind(this); 
    }
    
    componentDidMount() {
        this.bookList();
    }

    static renderBooksTable(books) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Book</th>
                        <th>Author</th>
                        <th>Publisher</th>
                        <th>Year</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book =>
                        <tr key={book.name}>
                            <td>{book.name}</td>
                            <td>{book.author}</td>
                            <td>{book.publisher}</td>
                            <td>{book.year}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    };
    
    mySubmitHandler = (event) => {
        event.preventDefault();
        fetch('books', {
            method: 'post',
            headers: {
                'Content-Type': 'application-json'
            },
            body: JSON.stringify({
                name: this.state.name,
                author: this.state.author,
                publisher: this.state.publisher,
                year: this.state.year
            })
        })
            .then(book => {
                this.setState(previous => ({
                    books: [...previous.books, book]
                }))
            })
            .then(res => res.json())
            .catch(err => console.log(err)); 
    }
//            .then(user => {
//                    this.props.addUserToState(user);
//                })
//            };
    
    myChangeHandler = (event) => {
        let nam = event.target.name;
        let val = event.target.value;
        this.setState({[nam]: val});
    }
    
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Books.renderBooksTable(this.state.books);
            
        return (
            <div>
                <h1 id="tabelLabel" >Library</h1>
                <p>List of books in our library</p>
                {contents}
                <form onSubmit={this.mySubmitHandler}>
                    <label>
                        Title:
                        <input type="text" name="name" onChange={this.myChangeHandler}/>
                    </label>
                    <br/>
                    <label>
                        Author:
                        <input type="text" name={"author"} onChange={this.myChangeHandler}/>
                    </label>
                    <br/>
                    <label>
                        Publisher:
                        <input type="text" name={"publisher"} onChange={this.myChangeHandler}/>
                    </label>
                    <br/>
                    <label>
                        Year:
                        <input type="text" name={"year"} onChange={this.myChangeHandler}/>
                    </label>
                    <input type="submit" value="Add book" />
                </form>
            </div>
        );
    }

    async bookList() {
        const response = await fetch('books');
        const data = await response.json();
        this.setState({books: data, loading: false});
    }
}
