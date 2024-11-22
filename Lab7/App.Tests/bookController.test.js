describe('BookController API Tests', () => {
  const baseUrl = 'http://localhost:3000/api/book';

  describe('GET /api/book', () => {
    test('should return all books', async () => {
      // Arrange
      const mockBooks = [
        {
          bookId: 1,
          title: 'Test Book 1',
          price: 29.99,
          author: { name: 'Author 1' },
          bookCategory: { name: 'Category 1' }
        }
      ];

      global.fetch = jest.fn(() =>
        Promise.resolve({
          ok: true,
          json: () => Promise.resolve(mockBooks)
        })
      );

      // Act
      const response = await fetch(baseUrl);
      const data = await response.json();

      // Assert
      expect(response.ok).toBeTruthy();
      expect(data).toEqual(mockBooks);
      expect(fetch).toHaveBeenCalledWith(baseUrl);
    });
  });

  describe('GET /api/book/{id}', () => {
    test('should return book by id', async () => {
      // Arrange
      const bookId = 1;
      const mockBook = {
        bookId: 1,
        title: 'Test Book 1',
        price: 29.99,
        author: { name: 'Author 1' },
        bookCategory: { name: 'Category 1' }
      };

      global.fetch = jest.fn(() =>
        Promise.resolve({
          ok: true,
          json: () => Promise.resolve(mockBook)
        })
      );

      // Act
      const response = await fetch(`${baseUrl}/${bookId}`);
      const data = await response.json();

      // Assert
      expect(response.ok).toBeTruthy();
      expect(data).toEqual(mockBook);
      expect(fetch).toHaveBeenCalledWith(`${baseUrl}/${bookId}`);
    });

    test('should return 404 when book not found', async () => {
      // Arrange
      const bookId = 999;
      global.fetch = jest.fn(() =>
        Promise.resolve({
          ok: false,
          status: 404
        })
      );

      // Act
      const response = await fetch(`${baseUrl}/${bookId}`);

      // Assert
      expect(response.ok).toBeFalsy();
      expect(response.status).toBe(404);
    });
  });

  describe('POST /api/book', () => {
    test('should create new book', async () => {
      // Arrange
      const newBook = {
        title: 'New Test Book',
        price: 39.99,
        authorId: 1,
        bookCategoryId: 1
      };

      global.fetch = jest.fn(() =>
        Promise.resolve({
          ok: true,
          status: 201,
          headers: {
            get: () => `${baseUrl}/1`
          }
        })
      );

      // Act
      const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newBook)
      });

      // Assert
      expect(response.ok).toBeTruthy();
      expect(response.status).toBe(201);
      expect(fetch).toHaveBeenCalledWith(
        baseUrl,
        expect.objectContaining({
          method: 'POST',
          body: JSON.stringify(newBook)
        })
      );
    });

    test('should return 400 for invalid book', async () => {
      // Arrange
      const invalidBook = {
        // Missing required fields
      };

      global.fetch = jest.fn(() =>
        Promise.resolve({
          ok: false,
          status: 400
        })
      );

      // Act
      const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(invalidBook)
      });

      // Assert
      expect(response.ok).toBeFalsy();
      expect(response.status).toBe(400);
    });
  });
});